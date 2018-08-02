using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HHackathon_Waste.Models
{
    public class WasteHub:Hub
    {
        public void PostScoreToServer(String Player, int Hole, int Score)
        {
            // send the new score to all the other clients
            Clients.All.SendMessageToClient(Player, Hole, Score);

            // store the scores in a 'global' table so new clients get a complete list
            DataTable ScoresTable = HttpContext.Current.Application["WasteTable"] as DataTable;

            DataRow CurrentPlayer = ScoresTable.Rows.Find(Player);

            CurrentPlayer[Hole] = Score;
        }
    }
}