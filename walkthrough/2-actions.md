# Actions

Now that we're set up to trigger from the SpectatorDashboard bots responses, let's set up what we're going to do with it.
For the Streamer.bot wiki steps on setting up actions, see [here](https://wiki.streamer.bot/en/Actions "Actions")

1. Select the Actions tab
2. Right-click in the actions window and select Add
2. Give it an appropriate name, such as "Auto-prediction"
<img title="Auto-prediction action" src="../images/Auto-prediction action.png">

3. Right-click in the Triggers window and select Core -> Commands -> Command Triggered, and select the regex command made previously
<img title="Add Trigger" src="../images/Add Trigger.png">
<img title="Select Command" src="../images/Select Command.png">

4. We now want to capture and make use of the response sent by SpectatorDashboard
Right-click in the Sub-Actions window and select Core -> Globals -> Global (Set), disable Persisted, set Variable Name to something appropriate, such as "matchInfo", and under Argument type in "rawInput"
<img title="Add Global (Set)" src="../images/Add Global (Set).png">
<img title="Set Global Variable" src="../images/Set Global Variable.png">

We can now access the match information by referring to the "matchInfo" variable in our code

5. Now that we've got the raw input from the response, we need to parse it out for the bits we need.
I've put together some code to do this [response-parsing.cs]("../src/"response-parsing.cs)
Right-click in the Sub-Actions window and select Core -> C# -> Execute C# Code, and replace the code you find there with [response-parsing.cs]("../src/"response-parsing.cs)
<img title="Add C# Code" src="../images/Add C sharp Code.png">
<img title="Parsing code" src="../images/Parsing code.png">

This now gives us global temp variables to work with, including: numPlayers, then player1Civ, player1Elo, player1Name, and player2Civ, player2Elo, player2Name, etc. for each player

6. With the response parsed, we now want to use the info to create the predication.
I've put together some code to do that [auto-prediction.cs]("../src/"auto-prediction.cs)
Right-click in the Sub-Actions window and select Core -> C# -> Execute C# Code, and replace the code you find there with [auto-prediction.cs]("../src/"auto-prediction.cs)
<img title="Auto-prediction code" src="../images/Auto-prediction code.png">

Completed Action should look like this:
<img title="Auto-prediction Action Complete" src="../images/Auto-prediction Action Complete.png">

And that should be it! Go forth and test it by having anyone type "#match" in the Twitch chat when you're live and playing or casting a game!