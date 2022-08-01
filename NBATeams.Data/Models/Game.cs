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

        public Team? Match()
        {
            var teamA = (Object)null;
            if (Local.OfficialTeam != null)
                teamA = Local.OfficialTeam;
            else
                teamA = Local.CustomTeam;

            var teamB = (Object)null;
            if (Local.OfficialTeam != null)
                teamB = Visit.OfficialTeam;
            else
                teamB = Visit.CustomTeam;

            int teamAAverage = ((OfficialTeam)teamA).AverageTeam();
            int teamBAverage = ((OfficialTeam)teamB).AverageTeam();



            if (teamAAverage > teamBAverage)
            {
                Team team;
                if(teamA is OfficialTeam)
                {
                     team = new Team()
                    {
                        OfficialTeam = (OfficialTeam)teamA
                    };
                }
                else
                {
                     team = new Team()
                    {
                        CustomTeam = (CustomTeam)teamA
                    };
                }
                return team;

            }
            if (teamAAverage < teamBAverage)
            {
                Team team;
                if (teamB is OfficialTeam)
                {
                    team = new Team()
                    {
                        OfficialTeam = (OfficialTeam)teamB
                    };
                }
                else
                {
                    team = new Team()
                    {
                        CustomTeam = (CustomTeam)teamB
                    };
                }
                return team;
            }
            return null;
        }

    }
}