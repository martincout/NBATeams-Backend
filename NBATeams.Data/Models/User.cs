﻿namespace NBATeams.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public List<CustomTeam> CustomTeams { get; set; } = new List<CustomTeam>();
    }
}