using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.DTOs
{
    public class OfficialTeamDTO
    {
        public CourtDTO Court { get; set; }
        public string LogoPath { get; set; }
        public List<AwardDTO> Awards { get; set; } = new List<AwardDTO>();
    }
}
