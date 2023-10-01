using System;
using System.Text.RegularExpressions;

public class CPHInline {
  public bool Execute() {
    // The temp variable that contains the match information
    var matchInfo = CPH.GetGlobalVar < string > ("matchInfo", false);

    // Regular expression to match players' names, ranked elos, civs, and colours/numbers
    Regex rx = new Regex(@"([🔵|🔴|🟢|🟡|Ⓜ️|🟣|⚪|🟠].+? \([0-9]{1,4}\) as \w+)");

    // The MatchCollection list that contains the collection of players info
    MatchCollection allPlayerInfo = rx.Matches(matchInfo);

    // Store the number of players in the match in a temp variable
    CPH.SetGlobalVar("numPlayers", allPlayerInfo.Count, false);

    // If the MatchCollection all players' info, assign the values to temp variables
    if (allPlayerInfo.Count > 1) {
      for (int i = 1; i <= allPlayerInfo.Count; i++) {
        // Parse each of the players' info: remove the "as", and split based on spaces around 2 brackets with 1-4 digits inside
        var playerInfo = Regex.Split(allPlayerInfo[i - 1].Value.Replace("as ", ""), @" \(([0-9]{1,4})+\) ");

        // If a player name is longer than the 25 character limit (https://dev.twitch.tv/docs/api/reference/#create-prediction), truncate        
        if (playerInfo[0].Length > 25) {
          playerInfo[0] = playerInfo[0].Substring(0, 25);
        }

        // Set the temp variables in Streamer.bot
        CPH.SetGlobalVar(String.Format("player{0}Name", i), playerInfo[0], false);
        CPH.SetGlobalVar(String.Format("player{0}Elo", i), int.Parse(playerInfo[1]), false);
        CPH.SetGlobalVar(String.Format("player{0}Civ", i), playerInfo[2], false);
        CPH.SetGlobalVar(String.Format("player{0}Colour", i), getColourNumber(playerInfo[0].Substring(0, 2)).Item1, false);
        CPH.SetGlobalVar(String.Format("player{0}Number", i), getColourNumber(playerInfo[0].Substring(0, 2)).Item2, false);
      }
    }
    return true;
  }
  public Tuple < string, int > getColourNumber(string colour) {
    if (colour == "🔵") {
      return Tuple.Create("blue", 1);
    } else if (colour.Contains("🔴")) {
      return Tuple.Create("red", 2);
    } else if (colour.Contains("🟢")) {
      return Tuple.Create("green", 3);
    } else if (colour.Contains("🟡")) {
      return Tuple.Create("yellow", 4);
    } else if (colour.Contains("Ⓜ️")) {
      return Tuple.Create("cyan", 5);
    } else if (colour.Contains("🟣")) {
      return Tuple.Create("magenta", 6);
    } else if (colour.Contains("⚪")) {
      return Tuple.Create("grey", 7);
    } else if (colour.Contains("🟠")) {
      return Tuple.Create("orange", 8);
    } else {
      return Tuple.Create("?", 0);
    }
  }
}