using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    public class CustomTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Lost { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public User User { get; set; }

        public int AverageTeam()
        {
            return Players.Select(x => x.Stats).Sum(x => x.AveragePoints());
        }
    }
}
