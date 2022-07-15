﻿namespace NBATeams.Data.Models
{
    public class Stat
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public decimal PPG { get; set; }
        public decimal RPG { get; set; }
        public decimal APG { get; set; }
        public decimal PIE { get; set; }
        public int Assists { get; set; }
        public int Score { get; set; }

        /// <summary>
        /// Calculates the average of all the values in order to qualify the Player by Its Stats and Scores.
        /// </summary>
        /// <returns>Average Score</returns>
        public decimal AverageScore()
        {
            return decimal.Round((PPG + RPG + APG + PIE + Assists + Score) / 6, 2);
        }

        /// <summary>
        /// Converts the Weight from Kilograms into Pounds
        /// </summary>
        /// <returns></returns>
        public double WeightInLB()
        {
            return Weight * 2.20462262185;
        }
    }
}