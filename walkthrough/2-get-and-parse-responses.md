# Get and Parse Responses

Now that we're set up to trigger from the SpectatorDashboard bot;s responses, let's get the info we need from it\
For the Streamer.bot wiki steps on setting up actions, see [here](https://wiki.streamer.bot/en/Actions "Actions")

1. Select the Actions tab
2. Right-click in the actions window and select Add
2. Give it an appropriate name, such as "Auto-prediction"
<img title="Auto-prediction action" src="../images/Auto-prediction action.png">

3. Right-click in the Triggers window and select Core -> Commands -> Command Triggered, and select the regex command made previously
<img title="Add Trigger" src="../images/Add Trigger.png">
<img title="Select Command" src="../images/Select Command.png">

4. We now want to capture the response sent by SpectatorDashboard in a variable we can use
Right-click in the Sub-Actions window and select Core -> Globals -> Global (Set), disable Persisted, set Variable Name to something appropriate, such as "matchInfo", and under Argument type in "rawInput"
<img title="Add Global (Set)" src="../images/Add Global (Set).png">
<img title="Set Global Variable" src="../images/Set Global Variable.png">

We can now access the match information by referring to the "matchInfo" variable in our code

5. Now that we've got the raw input from the response, let's parse it out into more variables we can use
I've put together some code to do this [response-parsing.cs]("../src/"response-parsing.cs)\
Right-click in the Sub-Actions window and select Core -> C# -> Execute C# Code, and replace the code you find there with [response-parsing.cs]("../src/"response-parsing.cs)
<img title="Add C# Code" src="../images/Add C sharp Code.png">
<img title="Parsing code" src="../images/Parsing code.png">

This now gives us global temp variables to work with:
- numPlayers
- player1Civ
- player1Elo
- player1Name
- player1Colour
- player1Number
- ^and same again for each other player

You're now able to access use those variables however you need!

[Next - Automatically Create Twitch Predictions](/3-create-prediction.md)