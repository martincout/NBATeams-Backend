namespace NBATeams.Data.Models
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
        public int Points { get; set; }

        /// <summary>
        /// Calculates the average of all the values in order to qualify the Player by Its Stats and Scores.
        /// </summary>
        /// <returns>Average Score</returns>
        public void AveragePoints()
        {
            this.average=(int)decimal.Round((PPG + RPG + APG + PIE + Assists + Points) / 6);
        }

        /// <summary>
        /// Converts the Weight from Kilograms into Pounds
        /// </summary>
        /// <returns>Pounds (LB)</returns>
        public double WeightInLB()
        {
            return Weight * 2.20462262185;
        }
        /// <summary>
        /// Converts the Height from Meters into Feet
        /// </summary>
        /// <returns>Feet</returns>
        public string HeightInFeet()
        {
            //Convert meters into feet
            double inFeet = Height / 0.3048;
            //Get the left part before the decimal point
            int ft = (int)inFeet;
            //Fetch the right part of Feet (after decimal point) and divide it by 0.08333 to convert it into Inches
            double temp = (inFeet - Math.Truncate(inFeet)) / 0.08333;
            //Get the int part
            double inchesLeft = (int)temp;
            //Return
            return ft + "'" + inchesLeft;
        }
    }
}