namespace NBATeams.Data.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public decimal PPG { get; set; }
        public decimal RPG { get; set; }
        public decimal APG { get; set; }
        public decimal PIE { get; set; }
    }
}