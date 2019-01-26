# UE-Optimizer
Optimizer for Unreal Engine based games

Optimizes some settings in UE .ini files on Windows platforms
by making changes proposed here: https://steamcommunity.com/app/200510/discussions/0/846960628563773260

It works by looking for .ini files for all UE based games in user/Documents folder,
making changes to them and setting Read Only attribute so games won't rollback changes.

The program automatically choose English or Russian interface language based on Windows GUI language (Russian for Russian, Ukrainian and Belarusian, and English for everyone else).

!!!IMPORTANT!!!

If you use mods for XCOM 2 you may need to find xcomengine.ini and remove ReadOnly from it as there are reports it may break the game and it seems XCOM 2 doesn't try to change values in xcomengine.ini back to default.

!!!IMPORTANT!!!

* Run a game at least once (it must generate .ini first).

* Select how much VRAM your video card has (if you have 4096Mb or more still select 3072Mb).

* The entry that needs a number of (CPU cores - 2) is detected and calculated automatically.

* Select a folder \ users \ yournamehere \ documents \ my games \ (it will preselect Documents folder for you).

* Then it will list all detected games and paths to their .ini files. Check what .ini files you want to modify and my program will do it for you (it will even make a backup of modified files).

* Click Apply and it will try to make a backup copy in the same directory, remove ReadOnly from an .ini file if present, make changes and place ReadOnly flag so a game won't change anything back.

* If you have a bunch of Access Errors try to launch in Admin mode.

* Run a game, reset graphic settings to default and set them again to your needs.

* The program now has an option to select whether your CPU is HT enabled, and you can also choose ratio of ThreadedShaderCompileThreshold to NumUnusedShaderCompilingThreads Max : 0, Max-2 : 2, Max/2 : Max/2
