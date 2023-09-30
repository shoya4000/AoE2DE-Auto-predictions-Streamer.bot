using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class CPHInline {
  public bool Execute() {
    // Get info about the match
    var matchInfo = CPH.GetGlobalVar < string > ("matchInfo", false);
    // Get number of players
    var numPlayers = CPH.GetGlobalVar < int > ("numPlayers", false);
    
    // Get number of teams
    Regex rx = new Regex(@"( -VS- )");
    MatchCollection matches = rx.Matches(matchInfo);
    var numTeams = matches.Count + 1;
    
    // Title is the title of the prediction
    var title = "Who wins this game?";
    // Options stores each of the prediction choices
    var options = new List < string > ();
    // Duration of the prediction, in seconds
    var duration = 180;
    
    // Define all of the options for the prediction
    for (int i = 0; i < numTeams; i++) {
      // Get the name of the first player on each team
      var teamLead = CPH.GetGlobalVar < string > (String.Format("player{0}Name", (i * (numPlayers / numTeams)) + 1), false);
      // If there are more than 1 player on each team, will need to add that to option name
      if (numPlayers > numTeams) {
        //if teamlead name is too long for 25 character limit, truncate it
        if (teamLead.Length > 18) {
          teamLead = teamLead.Substring(0, 18);
        }
        // And teamLead to options
        options.Add(teamLead + "'s team");
      } else {
        // Add solo player to options
        options.Add(teamLead);
      }
    }
  
  // Fire off the command to Twitch to create the prediction
    CPH.TwitchPredictionCreate(title, options, duration);
    return true;
  }
}