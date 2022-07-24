using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Court Court { get; set; }
        public string LogoPath { get; set; }
        public int Wins { get; set; }
        public int Lost { get; set; }
        public List<Award> Awards { get; set; } = new List<Award>();
        public List<Player> Players { get; set; } = new List<Player>();
        public int AverageTeam()
        {
            return Awards.Count;
        }
    }
}
