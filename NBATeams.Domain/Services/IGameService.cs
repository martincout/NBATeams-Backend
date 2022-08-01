using NBATeams.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.Services
{
    public interface IGameService
    {
        public Team MatchTwoTeams(int teamA, int teamB);

    }
}
