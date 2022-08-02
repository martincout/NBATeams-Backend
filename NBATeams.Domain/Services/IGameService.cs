using NBATeams.Data.Models;
using NBATeams.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.Services
{
    public interface IGameService
    {
        public WinnerTeamDTO? MatchTwoTeams(int teamA, int teamB);

    }
}
