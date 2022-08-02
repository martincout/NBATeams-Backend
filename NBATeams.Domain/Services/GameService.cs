using NBATeams.Data.Models;
using NBATeams.Data.Repositories;
using NBATeams.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerRepository _playerRepository;
        public GameService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        /// <summary>
        /// Plays a match between two teams and returns the winner
        /// </summary>
        /// <param name="teamA"></param>
        /// <param name="teamB"></param>
        /// <returns>A winner Team</returns>
        public WinnerTeamDTO? MatchTwoTeams(int teamAId, int teamBId)
        {
            Team Local = _playerRepository.GetTeamById(teamAId);
            Team Visit = _playerRepository.GetTeamById(teamBId);

            IEnumerable<Player> playersB;
            IEnumerable<Player> playersA;

            if (Local.GetTeam() is OfficialTeam) {
                playersA = _playerRepository.GetPlayersByTeamId(Local.Id);
            }
            else {
                playersA = _playerRepository.GetPlayersCustomTeamById(Local.Id);
            }

            if (Visit.GetTeam() is OfficialTeam)
            {
                playersB = _playerRepository.GetPlayersByTeamId(Visit.Id);
            }
            else
            {
                playersB = _playerRepository.GetPlayersCustomTeamById(Visit.Id);
            }

            Game game = new Game()
            {
                Local = Local,
                Visit = Visit
            };
            
            int teamAAverage = playersA.Select(x => x.Stats).Sum(x => x.AveragePoints());
            int teamBAverage = playersB.Select(x => x.Stats).Sum(x => x.AveragePoints());

            WinnerTeamDTO? winner = new WinnerTeamDTO();

            if (teamAAverage > teamBAverage)
            {
                winner = new WinnerTeamDTO()
                {
                    Id = Local.Id,
                    Name = Local.GetTeamName(),
                    AverageTeam = teamAAverage
                };

            }
            if (teamAAverage < teamBAverage)
            {
                winner = new WinnerTeamDTO()
                {
                    Id = Visit.Id,
                    Name = Visit.GetTeamName(),
                    AverageTeam = teamBAverage
                };
            }

            return winner;
        }

    }
}
