using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    public abstract class TeamType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public abstract int AverageTeam();
    }
}
