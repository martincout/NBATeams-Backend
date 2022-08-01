using NBATeams.Data.Models;
using NBATeams.Data.Repositories;
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
        public Team? MatchTwoTeams(int teamAId, int teamBId)
        {
            Team teamA = _playerRepository.GetTeamById(teamAId);
            Team teamB = _playerRepository.GetTeamById(teamBId);
            Game game = new Game()
            {
                Local = teamA,
                Visit = teamB
            };
            Team? winner = game.Match();

            return winner;
        }
    }
}
