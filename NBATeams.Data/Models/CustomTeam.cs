using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    [Table("CustomTeams")]
    public class CustomTeam : Team
    {
        public User User { get; set; }
        public int Wins { get; set; } = 0;
        public int Lost { get; set; } = 0;
    }
}
