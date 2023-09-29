using System;
using System.Text.RegularExpressions;
public class CPHInline {
  public bool Execute() {
    // The variable that contains the information about the match
    var matchInfo = CPH.GetGlobalVar < string > ("globalmatchstuff");

    // The regular expression pattern to match players' names, ranked elos, and civs
    // This works with standard special characters, European language characters,
    // Vietnamese, Chinese, Japanese, Russian, Korean, and Greek, + some unique special characters used by top 1000 players
    var pattern = @"([a-zA-ZÀ-ȕẠ-Ỿ0-9!-\/:-@[-`{-~！• \u4E00-\u9FBF\u3040-\u309F\u30A0-\u30FF\u0400-\u04FF\uAC00-\uD7A3\u3000-\u303F\u0370-\u03FF]* \(([0-9]{1,4})+\) as \w+)";

    // The MatchCollection list that contains the results
    MatchCollection matches = Regex.Matches(matchInfo, pattern);
    CPH.SetGlobalVar("debug", matchInfo);

    CPH.SetGlobalVar("globalNumPlayers", matches.Count);
    // If the MatchCollection got both (or more) players' info, assign the values to the variables
    if (matches.Count > 1) {
      // Doing this in a for loop will make it easily scaled up for team games later
      for (int i = 1; i <= matches.Count; i++) {
        // Parse each of the players' info: remove the "as", and split based on spaces around 2 brackets with 1-4 digits inside
        // The only thing that could mess with this would be someone's name containing spaces around 2 brackets with 1-4 digits inside
        // Even then other player(s) show up fine, and no errors break it
        var playerInfo = Regex.Split(matches[i - 1].Value.Replace("as ", ""), @" \(([0-9]{1,4})+\) ");

        // Set the variables in streamer.bot using the SetVariable action
        // If player name is longer than limit (https://dev.twitch.tv/docs/api/reference/#create-prediction), truncate
        if (playerInfo[0].Length > 25) {
          playerInfo[0] = playerInfo[0].Substring(0, 25);
        }
        CPH.SetGlobalVar(String.Format("globalplayer{0}Name", i), playerInfo[0]);
        CPH.SetGlobalVar(String.Format("globalplayer{0}Elo", i), int.Parse(playerInfo[1]));
        CPH.SetGlobalVar(String.Format("globalplayer{0}Civ", i), playerInfo[2]);
      }
    }
    return true;
  }
}