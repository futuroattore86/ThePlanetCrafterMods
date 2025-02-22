# ThePlanetCrafterMods
BepInEx+Harmony mods for the Unity/Steam game The Planet Crafter

- Steam: https://store.steampowered.com/app/1284190/The_Planet_Crafter/
- GoG: https://www.gog.com/en/game/the_planet_crafter

Guide on dnSpy-based manual patches: https://steamcommunity.com/sharedfiles/filedetails/?id=2784319459

## Version <a href='https://github.com/akarnokd/ThePlanetCrafterMods/releases'><img src='https://img.shields.io/github/v/release/akarnokd/ThePlanetCrafterMods' alt='Latest GitHub Release Version'/></a>

[![Github All Releases](https://img.shields.io/github/downloads/akarnokd/ThePlanetCrafterMods/total.svg)](https://github.com/akarnokd/ThePlanetCrafterMods/releases)

:arrow_down_small: Download files from the releases: https://github.com/akarnokd/ThePlanetCrafterMods/releases/latest

## Supported Game Version: 0.7.009

Public releases are relatively infrequent (once in a few months). I'll do my best to keep my mods up-to-date in case something drastic changes inside the main game.

:warning: I have not tested my mods with the developer/preview/demo releases. They might work just fine or suddenly break.
I don't promise to fix my mods for these versions as they can get quite out-of-sync with the public release.

## Preparation

In order to use my or anyone other's mods, you need to install BepInEx first. The wiki has a guide for this:

https://planet-crafter.fandom.com/wiki/Modding#Using_Mods

When installing my mods, unzip the mod into the `BepInEx\Plugins` directory, including the folder inside the zip file.

You'll have a directory structure like this:

`BepInEx\Plugins\akarnokd - (UI) Pin Recipe to Screen\UIPinRecipe.dll`

Such organization avoids overwriting each others' files if they happen to be named the same as well as allows removing plugin files together 
by deleting the directory itself.

:warning: Enabling mods became a bit more involved in 0.7 and beyond.

The new Unity version the game uses has a feature/bug that prevents **all mods** from running beyond their initialization phase. To work around it, find the `BepInEx\config\BepInEx.cfg` file, and in it, set

`HideManagerGameObject = true`

# Mods

### Content

- [Command Console](#feat-command-console)
- [Multiplayer](https://github.com/akarnokd/ThePlanetCrafterMods/wiki/%28Feat%29-Multiplayer)
- [Technician's Exile](#feat-technicians-exile)
- [Space Cows](#feat-space-cows)
- [Plugin Update Checker](https://github.com/akarnokd/ThePlanetCrafterMods/wiki/%28Misc%29-Plugin-Update-Checker)

### Cheats

- [Asteroid Landing Position Override](#cheat-asteroid-landing-position-override)
- [Auto Consume Oxygen-Water-Food](#cheat-auto-consume-oxygen-water-food)
- [Auto Harvest](#cheat-auto-harvest)
- [Auto Launch Rockets](#cheat-auto-launch-rockets)
- [Auto Sequence DNA](#cheat-auto-sequence-dna)
- [Birthday](#cheat-birthday)
- [Highlight Nearby Resources](#cheat-highlight-nearby-resources)
- [Inventory Stacking](#cheat-inventory-stacking)
- [Machines Deposit Into Remote Containers](#cheat-machines-deposit-into-remote-containers)
- [Minimap](#cheat-minimap)
- [Photomode Hide Water](#cheat-photomode-hide-water)
- [Recyclers Deposit Into Remote Containers](#cheat-recyclers-deposit-into-remote-containers)
- [Teleport to Nearest Minable](#cheat-teleport-to-nearest-minable)

### User Interface or Quality of Life

- [Beacon Text](#ui-beacon-text)
- [Craft Equipment Inplace](#ui-craft-equipment-inplace)
- [Český překlad](#ui-cesky-preklad) (Czech translation)
- [Customize Inventory Sort Order](#ui-customize-inventory-sort-order)
- [Don't Close Craft Window](#ui-dont-close-craft-window)
- [Hotbar](#ui-hotbar)
- [Inventory Move Multiple Items](#ui-inventory-move-multiple-items)
- [Logistic Select All](#logistic-select-all)
- [Magyar Fordítás](#ui-hungarian-translation) (Hungarian translation)
- [Menu Shortcut Keys](#ui-menu-shortcut-keys)
- [Overview Panel](#ui-overview-panel)
- [Pin Recipe to Screen](#ui-pin-recipe-to-screen)
- [Prevent Accidental Deconstruct](#ui-prevent-accidental-deconstruct)
- [Save When Quitting](#ui-save-when-quitting)
- [Show Consumable Counts](#ui-show-consumable-counts)
- [Show Container Content Info](#ui-show-container-content-info)
- [Show ETA](#ui-show-eta)
- [Show Grab N Mine Count](#ui-show-grab-n-mine-count)
- [Show MultiTool Mode](#ui-show-multitool-mode)
- [Show Player Inventory Counts](#ui-show-player-inventory-counts)
- [Show Player Tooltip Item Count](#ui-show-player-tooltip-item-count)
- [Show Rocket Counts](#ui-show-rocket-counts)
- [Sort Saves](#ui-sort-saves)
- [Traduzione Italiana](#ui-italian-translation) (Italian translation)

### Other

- [Reduce Save Size](#perf-reduce-save-size)
- [Save Auto Backup](#save-auto-backup)
- [Auto Save](#save-auto-save)
- [Unbrick Save](#fix-unbrick-save)
- [Unofficial Patches](#fix-unofficial-patches)

### Mods from former Modders

#### Lathrey

- [Auto Move](#lathrey-auto-move)
- [Disable Build Constraints](#lathrey-disable-build-constraints)

## (Cheat) Asteroid Landing Position Override

Fixes the asteroid landing position relative to the player by an offset.
This includes asteroids from rockets and random meteor showers.

Note that currently, this may fail if the landing position is determined by the game as invalid. Be in the clear open!

### Configuration

`akarnokd.theplanetcraftermods.cheatasteroidlandingposition.cfg`

```
[General]

## Relative position east-west (east is positive).
# Setting type: Int32
# Default value: 100
DeltaX = 100

## Relative position north-south (north is positive).
# Setting type: Int32
# Default value: 0
DeltaZ = 0
```

## (Cheat) Auto Consume Oxygen-Water-Food

When the Oxygen, Thirst and Health meters reach a critical level, this mod will automatically
consume an Oxygen bottle, Water bottle or any food item from the player's inventory.

Marked as cheat because it is expected the player does these manually.

### Configuration

`akarnokd.theplanetcraftermods.cheatautoconsume.cfg`

```
[General]

## The percentage for which below food/water/oxygen is consumed.
# Setting type: Int32
# Default value: 9
Threshold = 9
```

## (Cheat) Auto Harvest

Automatically harvest grown algae or food from their machines and deposit them into designated containers.

To deposit **Algae**, name any number of containers as `*Algae1Seed` (the `*` is mandatory).

To deposit food, use the following default naming convention:

- **Eggplant** - `*Vegetable0Growable`
- **Squash** - `*Vegetable1Growable`
- **Beans** - `*Vegetable2Growable`
- **Mushroom** - `*Vegetable3Growable`
- **Cocoa** - `*CookCocoaGrowable`
- **Wheat** - `*CookWheatGrowable`

The naming is case insensitive.

It is possible to change these aliases via configuration. If customized, the `*` is no longer needed. The mod defaults to the naming convention above to remain compatible with previous versions of itself.

### Configuration

<details><summary>`akarnokd.theplanetcraftermods.cheatautoharvest.cfg`</summary>

```
[General]

## Enable auto harvesting for algae.
# Setting type: Boolean
# Default value: true
HarvestAlgae = true

## Enable auto harvesting for food.
# Setting type: Boolean
# Default value: true
HarvestFood = true

## The container name to put algae into.
# Setting type: String
# Default value: *Algae1Seed
AliasAlgae = *Algae1Seed

## The container name to put eggplant into.
# Setting type: String
# Default value: *Vegetable0Growable
AliasEggplant = *Vegetable0Growable

## The container name to put squash into.
# Setting type: String
# Default value: *Vegetable1Growable
AliasSquash = *Vegetable1Growable

## The container name to put beans into.
# Setting type: String
# Default value: *Vegetable2Growable
AliasBeans = *Vegetable2Growable

## The container name to put mushroom into.
# Setting type: String
# Default value: *Vegetable3Growable
AliasMushroom = *Vegetable3Growable

## The container name to put cocoa into.
# Setting type: String
# Default value: *CookCocoaGrowable
AliasCocoa = *CookCocoaGrowable

## The container name to put wheat into.
# Setting type: String
# Default value: *CookWheatGrowable
AliasWheat = *CookWheatGrowable
```

</details>

## (Cheat) Auto Launch Rockets

Rockets crafted via the launchpad are automatically launched.

### Configuration

`akarnokd.theplanetcraftermods.cheatautolaunchrocket.cfg`

```

[General]

## Is the mod enabled?
# Setting type: Boolean
# Default value: true
Enabled = true

## Enable debugging with detailed logs (chatty!).
# Setting type: Boolean
# Default value: false
DebugMode = false
```

## (Cheat) Auto Sequence DNA

Automatically sequences DNA in the Sequencer or Incubator by collecting ingredients
from marked container(s), starting the sequencing process, then depositing the product
into marked container(s).

One marks a container by changing its text field to something specific. By default, the
following naming convention is used (can be changed in the config file):

On the recipe side:
- `*Larvae` - where the various common, uncommon and rare larvae will be searched for.
- `*Mutagen` - where the *Mutagen* ingredient is searched for.
- `*Fertilizer` - where the *Fertilizer* ingredient is searched for.
- `*TreeRoot` - where the *Tree Root* ingredient is searched for.
- `*FlowerSeed` - where the various *Flower Seed* ingredient is searched for.
- `*Phytoplankton` - where the various *Phytoplankton* ingredient is searched for.

On the product side:
- `*Butterfly` - where to deposit the created *Butterfly larvae* (all kinds).
- `*Bee` - where to deposit the created *Bee*s.
- `*Silk` - where to deposit the created *Silk Worm*s.
- `*TreeSeed` - where to deposit the created *Tree Seed*s (all kinds).
- `*Fish` - where to deposit the created *Fish* (all kinds).

(Note. Unlike other similar mods, you don't need to start the naming with the star `*` character. The defaults shown are just a convention I use.)

You can name as many containers like this as you want. If a source container does not contain an item,
it will search the next container. If a destination container is full, it will search for the next container.

The *Sequencer* and *Incubator* both require *Mutagen* and you can name different or the same containers where
they would both get their ingredients from.

### Configuration

<details><summary>akarnokd.theplanetcraftermods.cheatautosequencedna.cfg</summary>

```
[General]

## Enable debugging with detailed logs (chatty!).
# Setting type: Boolean
# Default value: false
DebugMode = false

[Incubator]

## Should the Incubator auto sequence?
# Setting type: Boolean
# Default value: true
Enabled = true

## The name of the container(s) where to look for fertilizer.
# Setting type: String
# Default value: *Fertilizer
Fertilizer = *Fertilizer

## The name of the container(s) where to look for mutagen.
# Setting type: String
# Default value: *Mutagen
Mutagen = *Mutagen

## The name of the container(s) where to look for larvae (common, uncommon, rare).
# Setting type: String
# Default value: *Larvae
Larvae = *Larvae

## The name of the container(s) where to deposit the spawned butterflies.
# Setting type: String
# Default value: *Butterfly
Butterfly = *Butterfly

## The name of the container(s) where to deposit the spawned bees.
# Setting type: String
# Default value: *Bee
Bee = *Bee

## The name of the container(s) where to deposit the spawned silk worms.
# Setting type: String
# Default value: *Silk
Silk = *Silk

## The name of the container(s) where to look for Phytoplankton.
# Setting type: String
# Default value: *Phytoplankton
Phytoplankton = *Phytoplankton

## The name of the container(s) where to deposit the spawned fish.
# Setting type: String
# Default value: *Fish
Fish = *Fish

[Sequencer]

## Should the Tree-sequencer auto sequence?
# Setting type: Boolean
# Default value: true
Enabled = true

## The name of the container(s) where to look for fertilizer.
# Setting type: String
# Default value: *Mutagen
Mutagen = *Mutagen

## The name of the container(s) where to look for Tree Root.
# Setting type: String
# Default value: *TreeRoot
TreeRoot = *TreeRoot

## The name of the container(s) where to look for Flower Seeds (all kinds).
# Setting type: String
# Default value: *FlowerSeed
FlowerSeed = *FlowerSeed

## The name of the container(s) where to deposit the spawned tree seeds.
# Setting type: String
# Default value: *TreeSeed
TreeSeed = *TreeSeed
```
</details>

## (Cheat) Photomode Hide Water

Press <kbd>Shift+F2</kbd> to toggle photomode and hide water as well.

This is marked as cheat because allows picking up objects near the water edge
where they can't be picked up normally.

### Configuration

None.

## (Cheat) Highlight Nearby Resources

Press <kbd>X</kbd> to highlight nearby resources.
Press <kbd>Shift+X</kbd> to highlight and cycle forward through the set of resources configured.
Press <kbd>Ctrl+X</kbd> to highlight and cycle backward through the set of resources configured.

### Configuration

`akarnokd.theplanetcraftermods.cheatnearbyresourceshighlight.cfg`

```
[General]

## Specifies how far to look for resources.
# Setting type: Int32
# Default value: 30
Radius = 30

## Specifies how high the resource image to stretch.
# Setting type: Int32
# Default value: 1
StretchY = 1

## List of comma-separated resource ids to look for.
# Setting type: String
# Default value: Cobalt,Silicon,Iron,ice,Magnesium,Titanium,Aluminium,Uranim,Iridium,Alloy,Zeolite,Osmium,Sulfur,PulsarQuartz,PulsarShard
ResourceSet = Cobalt,Silicon,Iron,ice,Magnesium,Titanium,Aluminium,Uranim,Iridium,Alloy,Zeolite,Osmium,Sulfur,PulsarQuartz,PulsarShard

## Key used for cycling resources from the set
# Setting type: String
# Default value: X
CycleResourceKey = X

## List of comma-separated larve ids to look for.
# Setting type: String
# Default value: LarvaeBase1,LarvaeBase2,LarvaeBase3,Butterfly11Larvae,Butterfly12Larvae,Butterfly13Larvae,Butterfly14Larvae,Butterfly15Larvae,Butterfly16Larvae,Butterfly17Larvae,Butterfly18Larvae
LarvaeSet = LarvaeBase1,LarvaeBase2,LarvaeBase3,Butterfly11Larvae,Butterfly12Larvae,Butterfly13Larvae,Butterfly14Larvae,Butterfly15Larvae,Butterfly16Larvae,Butterfly17Larvae,Butterfly18Larvae

## If nonzero, a thin white bar will appear and point to the resource
# Setting type: Single
# Default value: 5
LineIndicatorLength = 5

## How long the resource indicators should remain visible, in seconds.
# Setting type: Single
# Default value: 15
TimeToLive = 15

```

## (Cheat) Inventory Capacity Override

:warning: **Discontinued.**

This is a very basic override of game inventories, existing and new alike. It tries to not break certain containers
with capacity 1 or 3. Note that the game is not really setup to handle large inventories that don't fit on the screen.
This mod makes no attempts at remedying this shortcoming.

### Configuration

`akarnokd.theplanetcraftermods.cheatinventorycapacity.cfg`

```
[General]

## The overridden default inventory capacity.
# Setting type: Int32
# Default value: 250
Capacity = 250

## Is this mod enabled?
# Setting type: Boolean
# Default value: true
Enabled = false
```

## (Cheat) Machines Deposit Into Remote Containers

For this mod to work, you have to rename your containers. 

For the default naming convention, for example,
to make machines deposit Iron, rename your container(s) to something that includes
`*Iron`. For Uranium, rename them to `*Uranim` (remark: this is a misspelling in the vanilla game which will probably never be fixed as it would break saves). Note the `*` in front of the identifiers.
Identifiers can be any case. 

You can combine multiple resources by mentioning them together: `*Iron *Cobalt`.

Typical identifiers are: 
-`Cobalt`,`Silicon`,`Iron`,`ice`,
`Magnesium`,`Titanium`,`Aluminium`,`Uranim`,
`Iridium`,`Alloy`,`Zeolite`,`Osmium`,
`Sulfur`, `PulsarQuartz`

You can also make the water and methane extractors deposit remotely by naming containers:

- `*WaterBottle1`, `*OxygenCapsule1`, `*MethanCapsule1`

Biodome T2 generated tree barks can be deposited remotely too via `*TreeRoot`.

With Insects & Waterfalls update, the mod also works with Silk generators:

- `*Silk`

You can override the default naming convention via the `Aliases` configuration option by listing the resource id and the target naming:

`Aliases=Iron:A,Cobalt:B,Uranim:U`

The identifiers are case sensitive, the target names are case insensitive. You can have the same alias for multiple resources. With overrides, there is no need for the `*` prefix.

You can have as many containers as you like, but they will be filled in non-deterministically.
If there are no renamed containers or all renamed containers are full, the machines
will deposit the resource into their own container, as would they without this mod.

If the mod **Ore Extractor Tweaks** by *Lathrey* is present, its ore generator functionality is integrated with this mod. Specifically, if `configOnlyExtractDetectedOre` is true *and* a machine mines a common ore *and* there is no target inventory for it, the ore is not deposited anywhere.

Note also that machines are slow to mine resources.

### Configuration

`akarnokd.theplanetcraftermods.cheatmachineremotedeposit.cfg`

```
[General]
## A comma separated list of resourceId:aliasForId, for example, Iron:A,Cobalt:B,Uranim:C
# Setting type: String
# Default value: 
Aliases = 
```

## (Cheat) Teleport to Nearest Minable

Locates the nearest **minable resource** or **grabable larvae** (configurable).

- Press <kbd>F8</kbd> to teleport to the nearest **minable resource** or **grabable larvae**. 
- Press <kbd>Shift+F8</kbd> to teleport to the nearest minable resource/larvae and mine/grab it instantly. 
- Press <kbd>CTRL+F8</kbd> to mine/grab the nearest resource/larvae without moving the character. 
- Press <kbd>V</kbd> to toggle automatic mining/grabbing in a certain radius (configurable).

Note that some resources are out of bounds and are not normally player-reachable. You may also
fall to your death so be careful on permadeath!

:warning: Does not currently support Multiplayer-Client mode.

Remark: `Uranim` is a misspelling in the vanilla game which will probably never be fixed as it would break saves.

### Configuration

<details><summary>akarnokd.theplanetcraftermods.cheatteleportnearestminable.cfg</summary>

```
[General]

## List of comma-separated resource ids to look for.
# Setting type: String
# Default value: Cobalt,Silicon,Iron,ice,Magnesium,Titanium,Aluminium,Uranim,Iridium,Alloy,Zeolite,Osmium,Sulfur,PulsarQuartz,PulsarShard
ResourceSet = Cobalt,Silicon,Iron,ice,Magnesium,Titanium,Aluminium,Uranim,Iridium,Alloy,Zeolite,Osmium,Sulfur,PulsarQuartz,PulsarShard

## List of comma-separated larvae ids to look for.
# Setting type: String
# Default value: LarvaeBase1,LarvaeBase2,LarvaeBase3,Butterfly11Larvae,Butterfly12Larvae,Butterfly13Larvae,Butterfly14Larvae,Butterfly15Larvae,Butterfly16Larvae,Butterfly17Larvae,Butterfly18Larvae
LarvaeSet = LarvaeBase1,LarvaeBase2,LarvaeBase3,Butterfly11Larvae,Butterfly12Larvae,Butterfly13Larvae,Butterfly14Larvae,Butterfly15Larvae,Butterfly16Larvae,Butterfly17Larvae,Butterfly18Larvae

## Press this key (without modifiers) to enable automatic mining/grabbing in a radius.
# Setting type: String
# Default value: V
ToggleAutomatic = V

## The automatic mining/grabbing radius.
# Setting type: Single
# Default value: 90
Radius = 90

## The delay between automatic checks in seconds
# Setting type: Single
# Default value: 5
Delay = 5
```
</details>

## (Cheat) Minimap

Display a minimap on the lower left side of the screen.

Press <kbd>N</kbd> to show/hide the minimap.
Press <kbd>Shift+N</kbd> or <kbd>Mouse 4</kbd> to zoom in.
Press <kbd>Ctrl+N</kbd> or <kbd>Mouse 5</kbd> to zoom out.
Press <kbd>Alt+N</kbd> to show/hide/autoscan chests.

Notes
- Uses two static maps: barren and lush, where lush is currently set to show after 200 MTi.
- Currently, this was the best map that I could find and also wouldn't be huge.
- Can't do much about the rotating square, Unity has some UI rendering quirks.
- The current map is from https://map.fistshake.net/PlanetCrafter/ by **I crash at random** on the Steam Guides page https://steamcommunity.com/sharedfiles/filedetails/?id=2786757809


### Configuration

`akarnokd.theplanetcraftermods.cheatminimap.cfg`

```
[General]

## The minimap panel size
# Setting type: Int32
# Default value: 400
MapSize = 400

## Panel position from the bottom of the screen
# Setting type: Int32
# Default value: 350
MapBottom = 350

## Panel position from the left of the screen
# Setting type: Int32
# Default value: 0
MapLeft = 150

## The zoom level
# Setting type: Int32
# Default value: 4
ZoomLevel = 4

## The key to press to toggle the minimap
# Setting type: String
# Default value: N
ToggleKey = N

## Which mouse button to use for zooming in (0-none, 1-left, 2-right, 3-middle, 4-forward, 5-back)
# Setting type: Int32
# Default value: 4
ZoomInMouseButton = 4

## Which mouse button to use for zooming out (0-none, 1-left, 2-right, 3-middle, 4-forward, 5-back)
# Setting type: Int32
# Default value: 5
ZoomOutMouseButton = 5

## If nonzero and the minimap is visible, the minimap periodically scans for chests every N seconds. Toggle with Alt+N
# Setting type: Int32
# Default value: 5
AutoScanForChests = 5

## If negative, the map rotates on screen. If Positive, the map is fixed to that rotation in degrees (0..360).
# Setting type: Int32
# Default value: -1
FixedRotation = -1
```

## (Cheat) Inventory Stacking

Items in inventories now stack. The stack count is displayed on the middle of the item.

Use <kbd>Shift-Left Click</kbd> to move a particular stack of items.

:warning: The game is not meant to be working with stacks of items and I might not have
found all places where this can be bad. Backup your saves!

### Configuration

`akarnokd.theplanetcraftermods.cheatinventorystacking.cfg`

```
[General]

## The stack size of all item types in the inventory
# Setting type: Int32
# Default value: 10
StackSize = 10

## The font size for the stack amount
# Setting type: Int32
# Default value: 25
FontSize = 25
```

## (Perf) Load Inventories Faster

:warning: **Discontinued, now part of the vanilla game.**

This speeds up loading the game when there are lots of containers or (modded) containers have a lot of items.

### Configuration

None.

## (Fix) International Loading

:warning: **Discontinued, now fixed in the vanilla game.**

The game saves the beacon color information in a localized manner that crashes the game on a different windows locale. This mod fixes this by patching the color parsing so it accepts comma and colon as decimal separator.

### Configuration

None.

## (Fix) Unbrick Save

The mod prevents the game from crashing in case the save contains an unplaceable object (often added by 3rd party mods).

Current fixes:
- None.

Previous fixes
- Remove objects that can't or shouldn't be built as the game has no visual assets for them. **Fixed in game version 0.4.014**
- Prevent the load screen from crashing when a save is truncated (these are beyond repair). **Fixed in game version 0.4.014**

### Configuration

None.

## (Fix) Unofficial Patches

A mod that hosts the unofficial patches for the game. Eventually, these patches may end up becoming vanilla fixes.

Current fixes:
- Scroll the File List screen from whereever the mouse is currently at.
- Remove the dev-branch nagging screen.
- Prevent a silent crash when trying to place items on water but on an invalid position.
- Prevent a silent crash with butterfly flock management upon loading a save
- Prevent a silent crash with grabable vegetables upon quitting to the main menu.


### Configuration

None.

## (Feat) Space Cows

Place a Grass Spreader *(2 Water, 1 Magnesium, 1 Aluminium, 1 Lirma Seed)* and a **Space Cow** will appear.

Every 2 minutes, the Space Cow will produce 1 *Water*, 1 *Astrofood* and 1 *Methane Capsule*. 
Open her "inventory" and take them out. She won't produce more until then.

In addition, she will also add 60 grams to the *Animals* component of the Terraformation Index.

Why does it have a helmet? She dislikes your atmosphere.

:information_source: Since a Space Cow is not a machine or a grower, the various auto-gather/auto-deposit mods won't work.

### Configuration

`akarnokd.theplanetcraftermods.featspacecows.cfg`

```
[General]

## Is the mod enabled?
# Setting type: Boolean
# Default value: true
Enabled = true

## Enable debugging with detailed logs (chatty!).
# Setting type: Boolean
# Default value: false
DebugMode = false
```



## (Perf) Reduce Save Size

This mods the save process and removes attributes with default values from the `WorldObject`s, reducing
the save size. These attributes are automatically restored when the game loads.

The save remains compatible with the vanilla game so it will still work without this mod (but will be
full size again).

### Configuration

None.

## (Save) Auto Backup

When saving the game, this mod will automatically make a backup copy (optionally compressed) in a specified directory.
You can also control how many and how old backup saves to keep in this directory per world.

Start the game once so you get the default config file `BepInEx\config\akarnokd.theplanetcraftermods.saveautobackup.cfg`.
Quit, then open this file and set `OutputPath` to an **existing directory**. Example

```
OutputPath = c:\Temp\ThePlanetCrafterBackup\
```

Leave `OutputPath` empty to disable the backup process.

Files are saved based on the name of your world plus a timestamp:

- `Survival-9_backup_20220523_115024_255.json.gz`
- `Survival-9_backup_20220523_115024_255.json`

### Configuration

`akarnokd.theplanetcraftermods.saveautobackup.cfg`

```
[General]

## The path where the backups will be placed if not empty. Make sure this path exists!
# Setting type: String
# Default value: 
# c:\Temp\ThePlanetCrafterBackup\
OutputPath = 

## Compress the backups with GZIP?
# Setting type: Boolean
# Default value: true
GZIP = true

## If zero, all previous backups are retained. If positive, only that number of backups per world is kept and the old ones will be deleted
# Setting type: Int32
# Default value: 0
KeepCount = 0

## If zero, all previous backups are retained. If positive, backups older than this number of days will be deleted. Age is determined from the file name's timestamp part
# Setting type: Int32
# Default value: 0
KeepAge = 0

## If true, the backup handling is done asynchronously so the game doesn't hang during the process.
# Setting type: Boolean
# Default value: true
Async = true
```

## (Save) Auto Save

Saves the game automatically. You can configure the save period via the config file (default 5 minutes). You can use fractions such as
`0.5` to save every 30 seconds.

### Configuration

`akarnokd.theplanetcraftermods.saveautosave.cfg`

```
[General]

## Save delay in minutes. Set to 0 to disable.
# Setting type: Single
# Default value: 5
SaveDelay = 5
```

## (UI) Customize Inventory Sort Order

Specify the order of items when clicking on the sort all button in inventories.

### Configuration

`akarnokd.theplanetcraftermods.uicustominventorysortall.cfg`

```
[General]

## List of comma-separated resource ids to look for in order.
# Setting type: String
# Default value: OxygenCapsule1,WaterBottle1,astrofood
Preference = OxygenCapsule1,WaterBottle1,astrofood
```

## (UI) Prevent Accidental Deconstruct

When deconstructing, hold the accessibility key (default CTRL) too to prevent accidental deconstruction with a plain
left click.

The accessibility key is a vanilla feature, configurable in the game's settings menu.

### Configuration

`akarnokd.theplanetcraftermods.uideconstructpreventaccidental.cfg`

```
[General]

## Is the mod enabled?
# Setting type: Boolean
# Default value: true
Enabled = true
```


## (UI) Don't Close Craft Window

When crafting an item, <kbd>Right Click</kbd> to not close the crafting window.

Since vanilla **0.4.014**, there is an accessibility key (<kbd>CTRL</kbd> by default) which does the same as this mod.
However, it does not update the tooltip currently, but this mod does fix that.

### Configuration

None.

## (UI) Grower Grab Vegetable Only

:warning: **Discontinued. The vanilla game now grabs the vegetable only.**

When looking at a grown vegetable in a Grower, hold <kbd>Shift</kbd> while clicking
the vegetable itself to not take the seed, so it can immediately grow the next vegetable.

### Configuration

None.

## (UI) Hide Beacons in Photomode

:warning: **Discontinued. Fixed in the vanilla game.**

When using the photomode (<kbd>F2</kbd>), this mod will hide the user placed and colored
beacons.

### Configuration

None.

## (UI) Hotbar

This mod adds 9 slots to the bottom of the screen where you can pin buildable objects from the Constuction screen <kbd>Q</kbd>.

On the construction screen, hold the <kbd>1</kbd>..<kbd>9</kbd> number keys while <kbd>Left clicking</kbd> on a buildable item.

On the normal screen (outside any UI), press <kbd>1</kbd>..<kbd>9</kbd> to build that item if you have enough resources for it.

If the mod [**(UI) Pin Recipe To Screen**](#ui-pin-recipe-to-screen) is also installed,
On the normal screen (outside any UI), press <kbd>Shift+1</kbd>..<kbd>Shift+9</kbd>
to pin/unpin the recipe to the item in the particular non-empty slot.

The color and numbers on the top right of the panels indicate how many of that item you can build.

- If the mod [**Craft From Containers**](https://www.nexusmods.com/planetcrafter/mods/9) by aedenthorn is installed and active (toggle via <kbd>Home</kbd> by default), nearby inventories are also considered when showing how many of the selected buildings one can build.

Multi-build is allowed by holding <kbd>CTRL</kbd> while clicking to build something over and over (vanilla feature as of 0.4.011, not affected by this mod).

### Configuration

`akarnokd.theplanetcraftermods.uihotbar.cfg`

```
[General]

## The size of each inventory slot
# Setting type: Int32
# Default value: 75
SlotSize = 75

## The font size of the slot index
# Setting type: Int32
# Default value: 20
FontSize = 20

## Placement of the panels relative to the bottom of the screen.
# Setting type: Int32
# Default value: 40
SlotBottom = 40
```

## (UI) Inventory Move Multiple Items

When transferring items between the player backpack and any container,
- Press <kbd>Middle Mouse</kbd> to transfer all items of the same type (i.e., all Iron)
- Press <kbd>Shift+Middle Mouse</kbd> to transfer a small amount of items of the same type (default 5)
- Press <kbd>Ctrl+Shift+Middle Mouse</kbd> to transfer a larger amount of items of the same type (default 50)

:information_source: The vanilla game now supports transferring all the same type of items via <kbd>CTRL</kbd>+<kbd>Left Mouse</kbd>.

### Configuration

`akarnokd.theplanetcraftermods.uiinventorymovemultiple.cfg`

```
[General]

## How many items to move when only a few to move.
# Setting type: Int32
# Default value: 5
MoveFewAmount = 5

## How many items to move when many to move.
# Setting type: Int32
# Default value: 50
MoveManyAmount = 50
```

## (UI) Overview Panel

Pressing the <kbd>F1</kbd> (configurable) shows an overview panel with the current status of the world, statistics and next unlocks.

### Configuration

`akarnokd.theplanetcraftermods.uioverviewpanel.cfg`

```
[General]

## Font size
# Setting type: Int32
# Default value: 19
FontSize = 19

## The keyboard key to toggle the panel (no modifiers)
# Setting type: String
# Default value: F1
Key = F1
```

## (UI) Show Consumable Counts

Next to the Health, Food and Water Gauges, display the number of consumables of each type
the player has in its inventory.

### Configuration

`akarnokd.theplanetcraftermods.uishowconsumablecount.cfg`

```
[General]

## The font size
# Setting type: Int32
# Default value: 20
FontSize = 20
```

## (UI) Show Container Content Info

When looking at a container before opening it, the tooltip at the bottom of the screen will show how many
items are in there, the capacity of the container and the very first item type.
(Pro tip: store different types of items in different containers)

Example: `Open Container [ 5 / 30 ] Cobalt`

### Configuration

None.

## (UI) Show Grab N Mine Count

When picking up items or mining ore, this mod will show a small information indicator (left side) for what you picked up
and how many of the same item is now in your inventory.

### Configuration

`akarnokd.theplanetcraftermods.uishowgrabnminecount.cfg`

```
[General]

## Is the visual notification enabled?
# Setting type: Boolean
# Default value: true
Enabled = true
```


## (UI) Show Player Inventory Counts

In the bottom left part of the screen, there are some numbers showing the player's position, status and
framerate. This mod will add the current number of inventory items, the inventory capacity and
how many items can be added to it.

Example: `800,0,100:4:60   <[  5  /  30  (  -25  )]>`

### Configuration

None.

## (UI) Show Player Tooltip Item Count

When in an inventory or build screen, in the tooltip of an item, show the number of items of the same
type in the player's backpack.

Example: `Cobalt x 5`

### Configuration

None.

## (UI) Show Rocket Counts

On the Terraformation information screen (one of the large screens), show the number of rockets used for
each type of terraformation effect: oxygen, heat, pressure, biomass, next to the current growth speed.

Example: ` 2 x -----    6000.00 nPa/s`

On the Launch Platform's crafting screen, the number of rockets are shown above each rocket type.

### Configuration

`akarnokd.theplanetcraftermods.uishowrocketcount.cfg`

```
[General]

## The font size of the counter text on the craft screen
# Setting type: Int32
# Default value: 20
FontSize = 20
```

## (UI) Show MultiTool Mode

Shows the current multitool mode as text and icon on the 2D hud. Useful when running the game on lower resolution and the tool's 3D image is cut off.

### Configuration

`akarnokd.theplanetcraftermods.uishowmultitoolmode.cfg`

```
[General]

## Show the current mode as text?
# Setting type: Boolean
# Default value: true
ShowText = true

## Show the current mode as icon?
# Setting type: Boolean
# Default value: true
ShowIcon = true

## The size of the font used
# Setting type: Int32
# Default value: 15
FontSize = 15

## The icon size
# Setting type: Int32
# Default value: 100
IconSize = 100

## The width of the text background
# Setting type: Int32
# Default value: 200
TextWidth = 200

## How transparent the text/icon background should be.
# Setting type: Int32
# Default value: 80
TransparencyPercent = 80

## Position of the text from the bottom of the screen
# Setting type: Int32
# Default value: 30
Bottom = 30

## Position of the text from the right of the screen
# Setting type: Int32
# Default value: 10
Right = 10
```

## (UI) Pin Recipe to Screen

On the various craft screens, use <kbd>Middle click</kbd> to pin or unpin a craftable recipe to the screen.

To unpin all recipes, press <kbd>C</kbd>.

In the panel, the curly parenthesis indicates how many of that item is in the player's inventory.
The `< 2 >` indicates how many of the recipe can be crafted from the given inventory.

Note that pinned recipes can't be saved currently as it requires save modding.

### Configuration

`akarnokd.theplanetcraftermods.uipinrecipe.cfg`

```cs
[General]

## The size of the font used
# Setting type: Int32
# Default value: 25
FontSize = 25

## The width of the recipe panel
# Setting type: Int32
# Default value: 850
PanelWidth = 850

## Panel position from the top of the screen.
# Setting type: Int32
# Default value: 150
PanelTop = 150

## The key to press to clear all pinned recipes
# Setting type: String
# Default value: C
ClearKey = C
```

## (UI) Beacon Text

Customize beacons by showing a custom title and the distance from the player. Click on the antenna part to open the text editor for the title.
*(Remark: the default three dots `...` is a vanilla thing for empty text; use a single space to show nothing)*

Use <kbd>B</kbd> (configurable) to toggle between showing no text, just the title, just the distance or both.

### Configuration

`akarnokd.theplanetcraftermods.uibeacontext`

```
[General]

## The font size
# Setting type: Int32
# Default value: 20
FontSize = 20

## Display: 0 - no text no distance, 1 - distance only, 2 - text only, 3 - distance + text
# Setting type: Int32
# Default value: 3
DisplayMode = 3

## The toggle key
# Setting type: String
# Default value: B
DisplayModeToggleKey = B
```


## (UI) Craft Equipment Inplace

When crafting upgrades to equimpent currently equipped, the newer equipment
will be replaced inplace. This avoids loosing backpack capacity or equipment capacity
for the duration of a traditional crafting step.

Note that the UI will indicate you are missing the equipment as an ingredient but
the crafting action will succeed if the rest of the materials are in your backpack.

:warning: Please make a backup of your save before attempting to use this mod, just in case.

### Configuration

None.

## (UI) Save When Quitting

Automatically saves the game when clicking the "Exit to main menu" button.

### Configuration

`akarnokd.theplanetcraftermods.saveonquit.cfg`

```
[General]

## Is the mod enabled?
# Setting type: Boolean
# Default value: true
Enabled = true
```

## (UI) Sort Saves

Allow sorting the save file list by time or name via clicking on buttons `[ <- ]` and `[ -> ]` or with <kbd>Left arrow</kbd> and <kbd>Right arrow</kbd> on the keyboard.

### Configuration

`akarnokd.theplanetcraftermods.uisortsaves.cfg`

```
[General]

## Sorting mode: 0=default, 1=newest, 2=oldest, 3=name ascending, 4=name descending
# Setting type: Int32
# Default value: 1
SortMode = 1

## The font size used
# Setting type: Int32
# Default value: 20
FontSize = 20
```

## (UI) Teleporter Scroll Targets

:warning: **Discontinued. The vanilla game now has a scrollbar on the teleporter screen.**

This mod allows scrolling the teleporter targets on screen by adding up and down buttons or via <kbd>Mouse scroll</kbd>. You can configure the number of targets shown at once.

### Config

`akarnokd.theplanetcraftermods.uiteleporterscroll.cfg`

```
[General]

## Maximum number of targets to show at once.
# Setting type: Int32
# Default value: 6
MaxTargets = 6
```

## (UI) Hungarian Translation

Patches in labels and enables switching to Hungarian ("Magyar") in the game's options screen. Note that some labels do not change when switching to Hungarian the first time. This is a bug in the vanilla game's UI and can be resolved by restarting the game.

The translation contains partly my own work, partly the translations (already accepted or still pending) provided by the community on https://www.localizor.com/the-planet-crafter/translate?language=5&key=297111 . Some consistency-adjustments were made.

:hungary:

Magyar nyelvűvé változtatja a játékot. A játék beállítások (Options) képernyőjén lévő nyelvi opciók közül a "Magyar" bejegyzést kell kiválasztani. Sajnos néhány felirat nem változik magyarrá az első nyelvváltás alkalmával. Ez egy hiba az eredeti játékban és a játék teljes újraindításával orvosolható.

A fordítás részben saját munka, részben a https://www.localizor.com/the-planet-crafter/translate?language=5&key=297111 weboldalon a közösség által
még nem vagy már elfogadott fordításokat tartalmazza. Néhány fordítás egy picit át lett alakítva a következetesség és konzisztencia érdekében.

## (UI) Italian Translation

Patches in labels and enables switching to Italian ("Italiano") in the game's options screen. Note that some labels do not change when switching to Italian the first time. This is a bug in the vanilla game's UI and can be resolved by restarting the game.

The translation was kindly provided by [Lorenza](https://github.com/LorenzaMX) (Discord: 𝕷𝖔𝖗𝖊𝖓𝖟𝖆#8158).

:information_source: If you find a problem with the translation, please provide such feedback in **English** as I don't speak Italian myself.

:it:

Patch nelle etichette e abilita il passaggio all'italiano ("Italiano") nella schermata delle opzioni del gioco. Si noti che alcune etichette non cambiano quando si passa all'italiano per la prima volta. Questo è un bug nell'interfaccia utente del gioco vanilla e può essere risolto riavviando il gioco.

La traduzione è stata gentilmente fornita da [Lorenza](https://github.com/LorenzaMX) (Discord: 𝕷𝖔𝖗𝖊𝖓𝖟𝖆#8158).


### Configuration

Only diagnostic options. Not relevant for the player.

## (UI) Czech Translation

Patches in labels and enables switching to Czech ("") in the game's options screen. Note that some labels do not change when switching to Czech the first time. This is a bug in the vanilla game's UI and can be resolved by restarting the game.

The translation was kindly provided by **Odo** (Discord: Odo#3718).

:information_source: If you find a problem with the translation, please provide such feedback in **English** as I don't speak Czech myself.

:cz:

Záplatuje štítky a umožňuje přepínání do češtiny ("česky") na obrazovce možností hry. Upozorňujeme, že některé štítky se při prvním přepnutí do češtiny nezmění. Toto je chyba v uživatelském rozhraní vanilkové hry a lze ji vyřešit restartováním hry.

Překlad laskavě poskytl **Odo** (Discord: Odo#3718).

:information_source: Pokud narazíte na problém s překladem, poskytněte mi prosím zpětnou vazbu v **angličtině**, protože sám neumím česky.


### Configuration

Only diagnostic options. Not relevant for the player.

## (UI) Polish Translation

Patches in labels and enables switching to Polish ("Polskie") in the game's options screen. Note that some labels do not change when switching to Polish the first time. This is a bug in the vanilla game's UI and can be resolved by restarting the game.

The translation was kindly provided by XXXX (Discord: XXX).

:information_source: If you find a problem with the translation, please provide such feedback in **English** as I don't speak Polish myself.

:pl:

TBD

### Configuration

Only diagnostic options. Not relevant for the player.

## (UI) Menu Shortcut Keys

Adds (configurable) keyboard shortcuts to the player's backpack screen, container screens (chests) and certain machine screens (to be expanded later).

The available shortcuts are displayed at the bottom of the screen.

Currently, the following shortcuts are supported:

- Backpack screen
  - Sort backpack (default <kbd>G</kbd>)
  - Sort equipment (default <kbd>T</kbd>)
- Construction screen
  - Toggle tier filter (default <kbd>F</kbd>). (Reminder: there is a new microchip that hides low tier machines if equipped. This key toggles this feature without the need to remove the chip).
- Container screens
  - Take All (default <kbd>R</kbd>) (Not all inventories allow this).
  - Sort backpack (default <kbd>G</kbd>)
  - Sort equipment (default <kbd>T</kbd>)
- Sequencer and Incubator
  - Sort backpack (default <kbd>G</kbd>)


### Configuration

`akarnokd.theplanetcraftermods.uimenushortcutkeys.cfg`

```
[General]

## The font size
# Setting type: Int32
# Default value: 20
FontSize = 20

## Toggle the tier-filter microchip's effect in the build screen
# Setting type: String
# Default value: F
BuildToggleFilter = <Keyboard>/F

## Take everything from the currently open container
# Setting type: String
# Default value: R
ContainerTakeAll = <Keyboard>/R

## Sort the player's inventory
# Setting type: String
# Default value: G
SortPlayerInventory = <Keyboard>/G

## Sort the other inventory
# Setting type: String
# Default value: T
SortOtherInventory = <Keyboard>/T
```

## (Feat) Command Console

When pressing <kbd>Enter</kbd> (configurable), a command window is shown where you can type in commands.

Only accessible if no other ingame dialogs are open.

Type in `/help` to see a list of commands. Type `/help [name]` to show a short description of that command. Most commands give you an usage example if run without parameters.

Notable commands:
- `/tp` - teleport
- `/spawn` - add an item to your inventory

### Configuration

`akarnokd.theplanetcraftermods.featcommandconsole.cfg`

```
[General]

## Enable this mod
# Setting type: Boolean
# Default value: true
Enabled = true

## Enable the detailed logging of this mod
# Setting type: Boolean
# Default value: false
DebugMode = true

## Key to open the console
# Setting type: String
# Default value: <Keyboard>/enter
ToggleKey = <Keyboard>/enter

## Console window's position relative to the top of the screen.
# Setting type: Int32
# Default value: 200
ConsoleTop = 100

## Console window's position relative to the left of the screen.
# Setting type: Int32
# Default value: 300
ConsoleLeft = 400

## Console window's position relative to the right of the screen.
# Setting type: Int32
# Default value: 200
ConsoleRight = 200

## Console window's position relative to the bottom of the screen.
# Setting type: Int32
# Default value: 200
ConsoleBottom = 200

## The font size in the console
# Setting type: Int32
# Default value: 20
FontSize = 20
```

## (Feat) Multiplayer

[See the wiki](https://github.com/akarnokd/ThePlanetCrafterMods/wiki/%28Feat%29-Multiplayer)


## (Feat) Technician's Exile

After reaching 1.1 MTi, soon you'll get some company. Follow the in-game clues in this light expansion of the game's world.

:warning: This is a new territory for me so I suggest making a backup of your save. Also if you build at a certain location of the map, this mod may not work correctly.

### Configuration

None.

## (Lib) Support Mods with Load n Save

:warning: Discontinued. Use a known item id and store excess data in its text attribute.

### How to achieve save-mod persistence?

Previously, this mod expanded the load and save process by appending more sections to the save. After I gained more experience with the game's code, it turns out this is/was completely unnnecessary.

A safer and compatible method is to convert the mod data into text and set it on a item id with known identifier. For example, a hidden Iron or Container1 item (i.e., their position and rotation are zeros).

You can use almost all identifiers between 0 and 200.000.000 with one restriction: the id can't start with `10` because those indicate pre-placed scene objects.

There is also the caveat of the text format: you can't have the pipe `|` or `@` characters in them (`|` is the line separator and `@` is the section separator). These charcters are not escaped by default in JSON.


## (Lathrey) Disable Build Constraints

Updated version of Lathrey's Disable Build Constraint mod. Lathrey no longer supports his mods.

Toggle the mode via Ctrl+G (configurable).

:warning: This mod runs in a different namespace thus it can't pick up your old configuration.

### Configuration

<details><summary>akarnokd.theplanetcraftermods.lathreydisablebuildconstraints.cfg</summary>

```
[General]

## Pick the modifier key to use in combination with the key to toggle building constraints off/on.
# Setting type: Key
# Default value: LeftCtrl
# Acceptable values: None, Space, Enter, Tab, Backquote, Quote, Semicolon, Comma, Period, Slash, Backslash, LeftBracket, RightBracket, Minus, Equals, A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Digit1, Digit2, Digit3, Digit4, Digit5, Digit6, Digit7, Digit8, Digit9, Digit0, LeftShift, RightShift, LeftAlt, RightAlt, AltGr, LeftCtrl, RightCtrl, LeftMeta, LeftWindows, LeftCommand, LeftApple, RightCommand, RightMeta, RightWindows, RightApple, ContextMenu, Escape, LeftArrow, RightArrow, UpArrow, DownArrow, Backspace, PageDown, PageUp, Home, End, Insert, Delete, CapsLock, NumLock, PrintScreen, ScrollLock, Pause, NumpadEnter, NumpadDivide, NumpadMultiply, NumpadPlus, NumpadMinus, NumpadPeriod, NumpadEquals, Numpad0, Numpad1, Numpad2, Numpad3, Numpad4, Numpad5, Numpad6, Numpad7, Numpad8, Numpad9, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, OEM1, OEM2, OEM3, OEM4, OEM5, IMESelected
Toggle_Build_Constraints_Modifier_Key = LeftCtrl

## Pick the key to use in combination with the modifier key to toggle building constraints off/on.
# Setting type: Key
# Default value: G
# Acceptable values: None, Space, Enter, Tab, Backquote, Quote, Semicolon, Comma, Period, Slash, Backslash, LeftBracket, RightBracket, Minus, Equals, A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Digit1, Digit2, Digit3, Digit4, Digit5, Digit6, Digit7, Digit8, Digit9, Digit0, LeftShift, RightShift, LeftAlt, RightAlt, AltGr, LeftCtrl, RightCtrl, LeftMeta, LeftWindows, LeftCommand, LeftApple, RightCommand, RightMeta, RightWindows, RightApple, ContextMenu, Escape, LeftArrow, RightArrow, UpArrow, DownArrow, Backspace, PageDown, PageUp, Home, End, Insert, Delete, CapsLock, NumLock, PrintScreen, ScrollLock, Pause, NumpadEnter, NumpadDivide, NumpadMultiply, NumpadPlus, NumpadMinus, NumpadPeriod, NumpadEquals, Numpad0, Numpad1, Numpad2, Numpad3, Numpad4, Numpad5, Numpad6, Numpad7, Numpad8, Numpad9, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, OEM1, OEM2, OEM3, OEM4, OEM5, IMESelected
Toggle_Build_Constraints_Key = G
```
</details>

## (Lathrey) Auto Move

Updated version of Lathrey's Auto Move mod. Lathrey no longer supports his mods.

Toggle the mode via CapsLock (configurable).

:warning: This mod runs in a different namespace thus it can't pick up your old configuration.

### Configuration

<details><summary>akarnokd.theplanetcraftermods.lathreyautomove.cfg</summary>

```
[General]

## Pick the modifier key to use in combination with the key to toggle auto move off/on.
# Setting type: Key
# Default value: None
# Acceptable values: None, Space, Enter, Tab, Backquote, Quote, Semicolon, Comma, Period, Slash, Backslash, LeftBracket, RightBracket, Minus, Equals, A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Digit1, Digit2, Digit3, Digit4, Digit5, Digit6, Digit7, Digit8, Digit9, Digit0, LeftShift, RightShift, LeftAlt, RightAlt, AltGr, LeftCtrl, RightCtrl, LeftMeta, LeftWindows, LeftCommand, LeftApple, RightCommand, RightMeta, RightWindows, RightApple, ContextMenu, Escape, LeftArrow, RightArrow, UpArrow, DownArrow, Backspace, PageDown, PageUp, Home, End, Insert, Delete, CapsLock, NumLock, PrintScreen, ScrollLock, Pause, NumpadEnter, NumpadDivide, NumpadMultiply, NumpadPlus, NumpadMinus, NumpadPeriod, NumpadEquals, Numpad0, Numpad1, Numpad2, Numpad3, Numpad4, Numpad5, Numpad6, Numpad7, Numpad8, Numpad9, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, OEM1, OEM2, OEM3, OEM4, OEM5, IMESelected
Toggle_Auto_Move_Modifier_Key = None

## Pick the key to use in combination with the modifier key to toggle auto move off/on.
# Setting type: Key
# Default value: CapsLock
# Acceptable values: None, Space, Enter, Tab, Backquote, Quote, Semicolon, Comma, Period, Slash, Backslash, LeftBracket, RightBracket, Minus, Equals, A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Digit1, Digit2, Digit3, Digit4, Digit5, Digit6, Digit7, Digit8, Digit9, Digit0, LeftShift, RightShift, LeftAlt, RightAlt, AltGr, LeftCtrl, RightCtrl, LeftMeta, LeftWindows, LeftCommand, LeftApple, RightCommand, RightMeta, RightWindows, RightApple, ContextMenu, Escape, LeftArrow, RightArrow, UpArrow, DownArrow, Backspace, PageDown, PageUp, Home, End, Insert, Delete, CapsLock, NumLock, PrintScreen, ScrollLock, Pause, NumpadEnter, NumpadDivide, NumpadMultiply, NumpadPlus, NumpadMinus, NumpadPeriod, NumpadEquals, Numpad0, Numpad1, Numpad2, Numpad3, Numpad4, Numpad5, Numpad6, Numpad7, Numpad8, Numpad9, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, OEM1, OEM2, OEM3, OEM4, OEM5, IMESelected
Toggle_Auto_Move_Key = CapsLock
```
</details>

## (UI) Logistic Select All

Select all groups in the logistic screen by pressing <kbd>Ctrl+A</kbd>.

### Configuration

None.

## (Cheat) Birthday

Re-enables the hidden Birthday underground base and the oven in there.

### Configuration

None.

## (UI) Show ETA

Show the time unit the next terraformation stage given the current speed of terraformation.

### Configuration

None.

## (Cheat) Recyclers Deposit Into Remote Containers

Recyclers deposit the decomposed ingredients into named containers. Supports automatic periodic recycling.

By default, all such ingredients would go into a container named `*Recycled` (case insensitive, can be configured). You can define a list of *item ids* (case sensitive) and *aliases* (case insensitive) to deposit various ingredients into such various named containers. Note that there are some vanilla misspellings (such as `Uranim` to look out for). 

Using the `*` prefix is not required with customized names, but it is recommended to avoid ambiguities with visible and mod-hidden containers.

You can define the automatic recycle period via configuration; default is every 5 seconds. Set it to zero to disable automatic recycling.

You can also define the maximum range (spherical) to look for the named containers.

:information_source: Note that some items can't be recycled because they have no ingredients associated with them or are explicitly forbidden to be recycled by the game.

:warning: if no aliases and no container named `*Recycled` can be found, the recyclers won't work, not even when pressing the button.


Example aliases:

```
DefaultDepositAliases = *Dump
CustomDepositAliases = Iron:*Common,Magnesium:*Common,Cobalt:*Common;Aluminium:*Precious;Iridium:*Precious
```

### Standard item identifiers

<details><summary>List of identifiers (case sensitive)</summary>

 - AirFilter1, Algae1Growable, Algae1Seed, Alloy, Aluminium
 - astrofood, astrofood2, Backpack1, Backpack2, Backpack3
 - Backpack4, Backpack5, Bacteria1, Bee1Hatched, Bee1Larvae
 - Bioplastic1, BlueprintT1, BootsSpeed1, BootsSpeed2, BootsSpeed3
 - Butterfly10Hatched, Butterfly10Larvae, Butterfly11Hatched, Butterfly11Larvae, Butterfly12Hatched
 - Butterfly12Larvae, Butterfly13Hatched, Butterfly13Larvae, Butterfly14Hatched, Butterfly14Larvae
 - Butterfly15Hatched, Butterfly15Larvae, Butterfly16Hatched, Butterfly16Larvae, Butterfly17Hatched
 - Butterfly17Larvae, Butterfly18Hatched, Butterfly18Larvae, Butterfly1Hatched, Butterfly1Larvae
 - Butterfly2Hatched, Butterfly2Larvae, Butterfly3Hatched, Butterfly3Larvae, Butterfly4Hatched
 - Butterfly4Larvae, Butterfly5Hatched, Butterfly5Larvae, Butterfly6Hatched, Butterfly6Larvae
 - Butterfly7Hatched, Butterfly7Larvae, Butterfly8Hatched, Butterfly8Larvae, Butterfly9Hatched
 - Butterfly9Larvae, CircuitBoard1, Cobalt, CookCake1, CookChocolate
 - CookCocoaGrowable, CookCocoaSeed, CookCookie1, CookCroissant, CookFlour
 - CookWheatGrowable, CookWheatSeed, Drone1, EquipmentIncrease1, EquipmentIncrease2
 - EquipmentIncrease3, FabricBlue, Fertilizer1, Fertilizer2, Firefly1Hatched
 - Fish10Eggs, Fish10Hatched, Fish11Eggs, Fish11Hatched, Fish1Eggs
 - Fish1Hatched, Fish2Eggs, Fish2Hatched, Fish3Eggs, Fish3Hatched
 - Fish4Eggs, Fish4Hatched, Fish5Eggs, Fish5Hatched, Fish6Eggs
 - Fish6Hatched, Fish7Eggs, Fish7Hatched, Fish8Eggs, Fish8Hatched
 - Fish9Eggs, Fish9Hatched, FusionEnergyCell, honey, HudChipCleanConstruction
 - HudCompass, ice, Iridium, Iron, Jetpack1
 - Jetpack2, Jetpack3, LarvaeBase1, LarvaeBase2, LarvaeBase3
 - Magnesium, MethanCapsule1, MultiBuild, MultiDeconstruct, MultiToolDeconstruct2
 - MultiToolLight, MultiToolLight2, MultiToolMineSpeed1, MultiToolMineSpeed2, MultiToolMineSpeed3
 - MultiToolMineSpeed4, Mutagen1, Mutagen2, Mutagen3, NitrogenCapsule1
 - Osmium, OxygenCapsule1, OxygenTank1, OxygenTank2, OxygenTank3
 - OxygenTank4, Phytoplankton1, Phytoplankton2, Phytoplankton3, Phytoplankton4
 - PulsarQuartz, RedPowder1, RocketBiomass1, RocketDrones1, RocketHeat1
 - RocketInformations1, RocketInsects1, RocketMap1, RocketMap2, RocketMap3
 - RocketMap4, RocketOxygen1, RocketPressure1, RocketReactor, Rod-alloy
 - Rod-iridium, Rod-osmium, Rod-uranium, Seed0, Seed0Growable
 - Seed1, Seed1Growable, Seed2, Seed2Growable, Seed3
 - Seed3Growable, Seed4, Seed4Growable, Seed5, Seed5Growable
 - Seed6, Seed6Growable, SeedGold, SeedGoldGrowable, Silicon
 - Silk, SilkWorm, Sulfur, Titanium, Tree0Growable
 - Tree0Seed, Tree1Growable, Tree1Seed, Tree2Growable, Tree2Seed
 - Tree3Growable, Tree3Seed, Tree4Growable, Tree4Seed, Tree5Growable
 - Tree5Seed, Tree6Growable, Tree6Seed, Tree7Growable, Tree7Seed
 - Tree8Growable, Tree8Seed, Tree9Growable, Tree9Seed, TreeRoot
 - Uranim, Vegetable0Growable, Vegetable0Seed, Vegetable1Growable, Vegetable1Seed
 - Vegetable2Growable, Vegetable2Seed, Vegetable3Growable, Vegetable3Seed, WardenKey
 - WaterBottle1, WaterFilter, Zeolite

</details>


### Configuration

<details><summary>akarnokd.theplanetcraftermods.cheatrecyclerremotedeposit.cfg</summary>

```
[General]

## Is the mod enabled?
# Setting type: Boolean
# Default value: true
Enabled = true

## Enable debug mode with detailed logging (chatty!)
# Setting type: Boolean
# Default value: false
DebugMode = false

## The name of the container to deposit resources not explicity mentioned in CustomDepositAliases.
# Setting type: String
# Default value: *Recycled
DefaultDepositAlias = *Recycled

## Comma separated list of resource_id:alias to deposit into such named containers
# Setting type: String
# Default value: 
CustomDepositAliases = 

## How often to auto-recycle, seconds. Zero means no auto-recycle.
# Setting type: Int32
# Default value: 5
AutoRecyclePeriod = 5

## The maximum range to look for containers within. Zero means unlimited range.
# Setting type: Int32
# Default value: 20
MaxRange = 20
```
</details>