using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    [Table("OfficialTeams")]
    public class OfficialTeam : Team
    {
        public Court Court { get; set; }
        public string LogoPath { get; set; }
        public List<Award> Awards { get; set; } = new List<Award>();
        
    }
}
