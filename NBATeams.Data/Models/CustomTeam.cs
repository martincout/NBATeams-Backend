using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    public class CustomTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public User User { get; set; }
        public int Wins { get; set; }
        public int Lost { get; set; }
    }
}
