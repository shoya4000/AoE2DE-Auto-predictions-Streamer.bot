using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class CPHInline {
  public bool Execute() {
    // Get info about the match
    var matchInfo = CPH.GetGlobalVar < string > ("globalmatchstuff");
    // Get number of players
    var numPlayers = CPH.GetGlobalVar < int > ("globalNumPlayers");

    // Get number of teams
    var pattern = @"( -VS- )";
    MatchCollection matches = Regex.Matches(matchInfo, pattern);
    var numTeams = matches.Count + 1;

    var title = "Who wins this game?";
    var options = new List < string > ();
    // Duration of the prediction, in seconds
    var duration = 180;

    // Get name of first player on each team
    for (int i = 0; i < numTeams; i++) {
      var teamLead = CPH.GetGlobalVar < string > (String.Format("globalplayer{0}Name", (i * (numPlayers / numTeams)) + 1));
      if (numPlayers > numTeams) {
        if (teamLead.Length > 18) {
          teamLead = teamLead.Substring(0, 18);
        }

        options.Add(teamLead + "'s team");
      } else {
        options.Add(teamLead);
      }
    }

    CPH.TwitchPredictionCreate(title, options, duration);
    return true;
  }
}