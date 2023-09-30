# AoE2DE-Auto-predictions-Streamer.bot
Setup, walkthrough. and code to use [Streamer.bot](https://streamer.bot/) to automatically generate channel predictions using responses from [SpectatorDashboard](https://aoe2recs.com/)

[Grathwrang](https://www.twitch.tv/grathwrang "Grathwrang") had the idea and was working to get this setup, and I hopped in to offer programming knowledge and assistance

This is the result of that, a tool for the AoE2DE community to use as you please!

## Input and Output

On a stream tracked by Spectator Dashboard, when a viewer types #match, a response appears in the chat from the [SpectatorDashboard bot](https://www.twitch.tv/spectatordashboard "SpectatorDashboard") with info about the currently streaming match, either played or spectated.

This project does two things with that response:
1. The response is parsed into variables that can be used elsewhere: number of players, and the player names, elos, and civs
2. The variables are used to start a Twitch auto-prediction. Works for any game with the same number of players on each team: 1v1, 1v1v1, 2v2, 3v3 etc. 

## Use

If you just want to import the actions and commands and get it working, see [quickuse](/quickuse.md)

See [walkthrough](/walkthrough) for a complete step-by-step breakdown of how it all works, and if you need to make any adjustments for your setup

## Planned additions

Will continue to add to this: 
1. Getting each player colour/player number from the match info
2. Steps for using the variable data with [CaptureAge](https://captureage.com/)
3. Please send further suggestions, feedback, and issues found to be fixed

## License

See the [LICENSE](LICENSE.txt) file for license rights and limitations (MIT)