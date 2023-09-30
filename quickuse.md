# Quickuse

Streamer.bot can quickly and easily [import and export](https://wiki.streamer.bot/en/Actions/Importing-and-Exporting) commands and actions.

To do so with this project:
1. Copy the data stored [here](/src/auto-prediction.txt)
2. In Streamer.bot, select Import, and paste into the Import String window
3. Click Import
4. Select the settings tab -> C# Compiler, and then right-click and select Add reference from file...\
It will open into the correct location, just find and select System.dll, and then System.Text.RegularExpressions.dll
<img title="C# Compiler settings" src="/images/C sharp Compiler settings.png">

And you should be good to go! Test it by having anyone type "#match" in the Twitch chat when you're live and playing or casting a game!