using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string? ImageProfilePath { get; set; }
        public string Position { get; set; }
        public Stat Stats { get; set; }
        public DateTime BirthDate { get; set; }
        public string Experience { get; set; } //Rookie, 2 year, 3 years.
        public OfficialTeam? Team { get; set; }
        public List<CustomTeam> CustomTeams { get; set; }
        public int Age()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - BirthDate.Year;
            if (DateTime.Today < BirthDate.AddYears(age))
            {
                return --age;
            }
            else
            {
                return age;
            }
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
