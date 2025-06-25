# TunicVanillaChecklist

A mod for finding and tracking all hidden chests/items in TUNIC.

This is largely a port of existing functionality from the [Randomizer Mod](https://github.com/silent-destroyer/tunic-randomizer) that works with vanilla save files.

## Features
- Open the inventory while in-game to view a summary of your game progress, including number of items in the current area.
- The Fairy Seeker spell will locate all chests and items in the game, useful for finding hidden chests that are obscured or out of sight.
  - If all items are found in an area, the Fairy Seeker spell will instead locate entrances to areas that have items.
- Interacting with the Mailbox at the start of the game will display a breakdown of the number of chests/items in each area of the game.

## Installation
- Download the [latest release](https://github.com/silent-destroyer/TunicVanillaChecklist/releases).
  - The release page contains a download for both BepInEx (the mod loader) and the mod itself.
- Extract the BepInEx zip into your TUNIC folder. Your TUNIC folder should have the following files/folder:
  - Make sure the individual files and folers are extracted directly in the TUNIC folder, and not in a folder within that folder.
  - Launch the game once and close it to finish installing BepInEx.
- Copy the TunicVanillaChecklist.dll into the BepInEx/plugins folder and launch the game.
