using System;
using System.Text.RegularExpressions;

public class CPHInline {
  public bool Execute() {
    // The temp variable that contains the match information
    var matchInfo = CPH.GetGlobalVar < string > ("matchInfo", false);

    // The regular expression pattern to match players' names, ranked elos, and civs
    // This works with standard special characters, European language characters,
    // Vietnamese, Chinese, Japanese, Russian, Korean, and Greek, + some unique special characters used by top 1000 players
    Regex rx = new Regex(@"([a-zA-ZÀ-ȕẠ-Ỿ0-9!-\/:-@[-`{-~！• \u4E00-\u9FBF\u3040-\u309F\u30A0-\u30FF\u0400-\u04FF\uAC00-\uD7A3\u3000-\u303F\u0370-\u03FF]* \(([0-9]{1,4})+\) as \w+)");

    // The MatchCollection list that contains the results
    MatchCollection matches = rx.Matches(matchInfo);
  
  // Store the number of players in the match in a temp variable
    CPH.SetGlobalVar("numPlayers", matches.Count, false);
    
    // If the MatchCollection all players' info, assign the values to temp variables
    if (matches.Count > 1) {
      for (int i = 1; i <= matches.Count; i++) {
        // Parse each of the players' info: remove the "as", and split based on spaces around 2 brackets with 1-4 digits inside
        var playerInfo = Regex.Split(matches[i - 1].Value.Replace("as ", ""), @" \(([0-9]{1,4})+\) ");
        
        // If a player name is longer than the 25 character limit (https://dev.twitch.tv/docs/api/reference/#create-prediction), truncate        
        if (playerInfo[0].Length > 25) {
          playerInfo[0] = playerInfo[0].Substring(0, 25);
        }

        // Set the temp variables in Streamer.bot
        CPH.SetGlobalVar(String.Format("player{0}Name", i), playerInfo[0], false);
        CPH.SetGlobalVar(String.Format("player{0}Elo", i), int.Parse(playerInfo[1]), false);
        CPH.SetGlobalVar(String.Format("player{0}Civ", i), playerInfo[2], false);
      }
    }
    return true;
  }
}