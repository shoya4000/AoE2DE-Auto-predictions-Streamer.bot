# Automatically Create Twitch Predictions

Now that we've processed the input, let's automatically create a channel prediction\
For the Streamer.bot wiki steps on setting up Predictions, see [here](https://wiki.streamer.bot/en/Platforms/Twitch/Predictions "Predictions")
For Twitch's information on Predictions, see [here](https://dev.twitch.tv/docs/api/predictions/#creating-a-prediction "Predictions")

1. With the variable we previously stored, we can now create the prediction.
I've put together some code to do that [auto-prediction.cs](../src/auto-prediction.cs)\
Right-click in the Sub-Actions window and select Core -> C# -> Execute C# Code, and replace the code you find there with [auto-prediction.cs](../src/auto-prediction.cs)
<img title="Auto-prediction code" src="../images/Auto-prediction code.png">

The completed Action should look like this:
<img title="Auto-prediction Action Complete" src="../images/Auto-prediction Action Complete.png">

And that should be it! Go forth and test it by having anyone type "#match" in the Twitch chat when you're live and playing or casting a game!
