﻿using BepInEx;
using HarmonyLib;
using SpaceCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FeatMultiplayer.MessageTypes;

namespace FeatMultiplayer
{
    public partial class Plugin : BaseUnityPlugin
    {
        /// <summary>
        /// The vanilla game uses ActionDeconstructible::FinalyDestroy to destroy the targeted
        /// world and game objects, and refund the materials for it.
        /// 
        /// On the host, we let it happen, then notify the client about the removal immediately.
        /// 
        /// On the client, we ask the host to deconstruct the object for us, and expect
        /// the host to do the refunding.
        /// </summary>
        /// <param name="__instance">The instance to use to find the game object</param>
        /// <returns>False for the client, true otherwise</returns>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ActionDeconstructible), "FinalyDestroy")]
        static bool ActionDeconstructible_FinalyDestroy(ActionDeconstructible __instance)
        {
            if (updateMode == MultiplayerMode.CoopClient)
            {
                GetPlayerMainController().GetAnimations().AnimateRecolt(false);
                WorldObjectAssociated component = __instance.gameObjectRoot.GetComponent<WorldObjectAssociated>();
                if (component != null)
                {
                    var wo = component.GetWorldObject();

                    LogInfo("ActionDeconstructible_FinalyDestroy: " + DebugWorldObject(wo));
                    SendHost(new MessageDeconstruct()
                    {
                        id = wo.GetId(),
                        groupId = wo.GetGroup().GetId()
                    }, true);
                }
                return false;
            }
            else
            if (updateMode == MultiplayerMode.CoopHost)
            {
                GetPlayerMainController().GetAnimations().AnimateRecolt(false);
                WorldObjectAssociated component = __instance.gameObjectRoot.GetComponent<WorldObjectAssociated>();
                if (component != null)
                {
                    var wo = component.GetWorldObject();
                    LogInfo("ActionDeconstructible_FinalyDestroy: " + DebugWorldObject(wo));

                    wo.ResetPositionAndRotation();
                    SendWorldObjectToClients(wo, false);
                }
            }
            return true;
        }

        /// <summary>
        /// The game uses ActionDeconstructible::Deconstruct to check if the object can be safely deconstructed,
        /// i.e., it is empty inside and its inventory is empty.
        /// 
        /// On the host, we let this happen.
        /// 
        /// On the client, we have to check if the object to be deconstructed has a scene inventory currently
        /// being spawned. If so, put up an inventory error.
        /// </summary>
        /// <param name="__instance">The instance being destructed</param>
        /// <param name="___hudHandler">The way to display messages</param>
        /// <returns>False if an inventory is being spawned for the object, true otherwise</returns>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ActionDeconstructible), "Deconstruct")]
        static bool ActionDeconstructible_Deconstruct(ActionDeconstructible __instance, BaseHudHandler ___hudHandler)
        {
            if (updateMode == MultiplayerMode.CoopClient)
            {
                InventoryAssociated component = __instance.gameObjectRoot.GetComponent<InventoryAssociated>();
                if (component != null) {
                    Inventory inv = component.GetInventory();
                    if (inventorySpawning.Contains(inv.GetId()))
                    {
                        LogInfo("ActionDeconstructible_Deconstruct: Inventory has not spawned yet: " + inv.GetId());

                        ___hudHandler.DisplayCursorText("UI_CantDeconstructIfInventory", 0f, "");
                        return false;
                    }
                }
            }
            return true;
        }

        static void ReceiveMessageDeconstruct(MessageDeconstruct md)
        {
            bool isSceneObject = WorldObjectsIdHandler.IsWorldObjectFromScene(md.id);

            if (!worldObjectById.TryGetValue(md.id, out var wo))
            {
                if (updateMode == MultiplayerMode.CoopHost && isSceneObject)
                {
                    wo = WorldObjectsHandler.CreateNewWorldObject(GroupsHandler.GetGroupViaId(md.groupId), md.id);
                    SendWorldObjectToClients(wo, false);
                }
            }
            if (wo != null)
            {
                if (TryGetGameObject(wo, out var go) && go != null)
                {
                    if (updateMode == MultiplayerMode.CoopHost)
                    {
                        // the base building resources
                        var ingredients = new List<Group>(wo.GetGroup().GetRecipe().GetIngredientsGroupInRecipe());
                        
                        // refund panels
                        foreach (Panel v in go.GetComponentsInChildren<Panel>())
                        {
                            GroupConstructible panelGroupConstructible = v.GetPanelGroupConstructible();
                            if (panelGroupConstructible != null)
                            {
                                ingredients.AddRange(panelGroupConstructible.GetRecipe().GetIngredientsGroupInRecipe());
                            }
                            v.ResetContigousPanel();
                        }

                        // Send out the resource objects
                        md.itemIds.Clear();
                        foreach (var g in ingredients)
                        {
                            var dwo = WorldObjectsHandler.CreateNewWorldObject(g, 0);
                            SendWorldObjectToClients(dwo, false);
                            md.itemIds.Add(dwo.GetId());
                        }
                        LogInfo("ReceiveMessageDeconstruct: Deconstructing " + DebugWorldObject(wo) + ", Ingredients = " + ingredients.Count);
                        md.sender.Send(md);
                        md.sender.Signal();

                        // everyone else just gets the destruction notification
                        var mdRest = new MessageDeconstruct();
                        mdRest.id = md.id;
                        SendAllClientsExcept(md.sender.id, mdRest, true);

                        if (go.GetComponent<WorldObjectFromScene>() != null)
                        {
                            wo.SetDontSaveMe(false);
                        }

                        go.GetComponent<RequireEnergy>()?.CheckEnergyStatus(false);

                        WorldObjectsHandler.DestroyWorldObject(wo);
                        TryRemoveGameObject(wo);
                        Destroy(go);
                    }
                    else
                    {
                        InformationsDisplayer informationsDisplayer = Managers.GetManager<DisplayersHandler>().GetInformationsDisplayer();
                        var inv = GetPlayerMainController().GetPlayerBackpack().GetInventory();

                        var dropAt = go.transform.position + new Vector3(0f, 1f, 0f);
                        float lifeTime = 2.5f;

                        foreach (var id in md.itemIds)
                        {
                            if (worldObjectById.TryGetValue(id, out var dwo))
                            {
                                if (inv.AddItem(dwo))
                                {
                                    informationsDisplayer.AddInformation(lifeTime, 
                                        Readable.GetGroupName(dwo.GetGroup()), 
                                        DataConfig.UiInformationsType.InInventory, 
                                        dwo.GetGroup().GetImage());
                                }
                                else
                                {
                                    WorldObjectsHandler.DropOnFloor(dwo, dropAt);
                                    informationsDisplayer.AddInformation(lifeTime,
                                        Readable.GetGroupName(dwo.GetGroup()),
                                        DataConfig.UiInformationsType.DropOnFloor,
                                        dwo.GetGroup().GetImage());
                                }
                            }
                            else
                            {
                                LogWarning("ReceiveMessageDeconstruct: Refund: Unknown WorldObject " + id + " of parent " + DebugWorldObject(wo));
                            }
                        }

                        WorldObjectsHandler.DestroyWorldObject(wo);
                        TryRemoveGameObject(wo);
                        Destroy(go);
                    }
                }
                else
                {
                    LogWarning("ReceiveMessageDeconstruct: Unknown gameObject for " + DebugWorldObject(wo));
                }
            }
            else
            {
                LogWarning("ReceiveMessageDeconstruct: Unknown WorldObject " + md.id);
            }
        }
    }
}
