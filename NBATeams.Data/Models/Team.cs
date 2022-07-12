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
        public List<Award> Awards { get; set; }
        public List<Player> Players { get; set; }
    }
}
