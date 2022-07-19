using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public int VisitId { get; set; }
        public DateTime DateGame { get; set; }
        public int ScoreLocal { get; set; }
        public int ScoreVisit { get; set; }
    }
}
