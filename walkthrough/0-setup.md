# Setup

1. Install [Streamer.bot](https://streamer.bot/ "Streamer.bot")
2. Connect Streamer.bot to your Twitch account, steps can be found here: [Twitch] (https://wiki.streamer.bot/en/Platforms/Twitch "Twitch")
3. Ensure your Twitch account is tracked by [Spectator Dashboard] (https://aoe2recs.com/ "Spectator Dashboard"). Expand the "Streamers" section in the bottom right corner to confirm set the stream URL
4. We use a couple specific C# libraries for the code parts and will need to have them available for the code to compile and run.
Select the settings tab -> C# Compiler, and then right-click and select Add reference from file...
It will open into the correct location, just find and select System.dll, and then System.Text.RegularExpressions.dll
<img title="C# Compiler settings" src="../images/C# Compiler settings.png">

## Optional
There will be some additional options for automating some interactions with [CaptureAge](https://captureage.com/ "CaptureAge"), install that as well if you like.