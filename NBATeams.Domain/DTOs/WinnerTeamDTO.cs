using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.DTOs
{
    public class WinnerTeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AverageTeam { get; set; } = 0;
    }
}
