using NBATeams.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.DTOs
{
    public class CustomTeamDTO
    {
        public UserDTO User { get; set; }
        public int Wins { get; set; } = 0;
        public int Lost { get; set; } = 0;
    }
}
