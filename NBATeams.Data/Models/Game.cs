using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBATeams.Data.Models
{
    public class Game
    {
        public int Id { get; set; }
        [ForeignKey("LocalId")]
        public Team Local { get; set; }
        [ForeignKey("VisitId")]
        public Team Visit { get; set; }
        public DateTime DateGame { get; set; }
        public int ScoreLocal { get; set; }
        public int ScoreVisit { get; set; }
    }
}