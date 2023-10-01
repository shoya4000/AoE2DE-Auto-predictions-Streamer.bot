# Create a Command to Trigger

When your stream URL is tracked by Spectator Dashboard, your chat has access to the #match command, which the [SpectatorDashboard bot](https://www.twitch.tv/spectatordashboard "SpectatorDashboard") responds to with info about your current match, either played or spectated

We want to capture the response from the bot. To do so, we're going to define a command which can only be called by a message sent to your Twitch chat by the bot\
For the Streamer.bot wiki steps on setting up commands, see [here](https://wiki.streamer.bot/en/Commands "Commands")

1. Select the Commands tab
2. Right-click in the commands window and select Add
3. Give it an appropriate name, such as "SpectatorDashboard live game info"
4. Select Mode and switch it from Basic to Regex
5. For the regex enter ```^(?!✔|✖).+ -VS- ```. This will check for any messages in the chat which include " -VS- " but do not have an ✔ or ✖, as those would indicate a past game, such as from the SpectatorDashboard bot's #lastmatch command\
For further information on how the regex works, see [here](https://regexr.com/7kvb2 "SpectatorDashboard live info")
6. Under Options disable Ignore Bot Account
7. Now, anyone in chat can activate this by typing a message that matches the regex. To limit this ability to only the SpectatorDashboard bot, select the User Permissions tab, filter for SpectatorDashboard, and add it to the Allowed list

Completed command should look like this:
<img title="SpectatorDashboard command" src="../images/SpectatorDashboard command.png">

[Next - Get and Parse Responses](/2-get-and-parse-responses.md)