using System;
namespace NBATeams.Data.Models
{
    public class Game
    {
        public Team Local { get; set; }

        public Team Visit { get; set; }

        public DateTime dateGame { get; set; }

        public int scoreLocal { get; set; }

        public int scoreVisit { get; set; }
    }
}