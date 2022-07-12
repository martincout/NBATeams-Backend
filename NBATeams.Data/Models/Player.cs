using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public int ImageProfilePath { get; set; }
        public string Position { get; set; }
        public Stat Stats { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Experience { get; set; } //Rookie, 2 year, 3 years.
        public Team Team { get; set; }
    }
}
