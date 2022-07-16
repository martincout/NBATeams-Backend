namespace NBATeams.Data.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public int playerId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public decimal PPG { get; set; }
        public decimal RPG { get; set; }
        public decimal APG { get; set; }
        public decimal PIE { get; set; }
        public int Assists { get; set; }
        public int Points { get; set; }

        /// <summary>
        /// Calculates the average of all the values in order to qualify the Player by Its Stats and Scores.
        /// </summary>
        /// <returns>Average Score</returns>
        public decimal AveragePoints()
        {
            return decimal.Round((PPG + RPG + APG + PIE + Assists + Points) / 6, 2);
        }
    }
}