using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.DTOs
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string ImageProfilePath { get; set; }
        public string Position { get; set; }
        public StatDTO Stats { get; set; }
        public DateTime BirthDate { get; set; }
        public string Experience { get; set; } //Rookie, 2 year, 3 years.
        public int TeamId { get; set; }
        public int Age { get; set; }
    }
}
