using System;
namespace NBATeams.Data.Models
{
    public class Award
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public OfficialTeam Team { get; set; }
    }
}