using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourtDTO Court { get; set; }
        public string LogoPath { get; set; }
        public int Wins { get; set; }
        public int Lost { get; set; }
        public List<AwardDTO> Awards { get; set; }
        public List<PlayerDTO> Players { get; set; }
        public int AverageOfTeam { get; set; }
    }
}
