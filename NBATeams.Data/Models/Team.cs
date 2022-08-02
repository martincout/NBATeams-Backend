using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    public class Team 
    {
        public int Id { get; set; }
        public OfficialTeam? OfficialTeam { get; set; }
        public CustomTeam? CustomTeam { get; set; }

        public string GetTeamName()
        {
            if(OfficialTeam != null) return OfficialTeam.Name;
            if(CustomTeam != null) return CustomTeam.Name;
            return "";
        }

        public TeamType? GetTeam()
        {
            if (OfficialTeam != null) return OfficialTeam;
            if (CustomTeam != null) return CustomTeam;
            return null;
        }
    }
}
