using AutoMapper;
using NBATeams.Data.Data;
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
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository context,IMapper mapper)
        {
            _playerRepository = context;
            _mapper = mapper;
        }
        public IEnumerable<GameDTO> GetAllGames()
        {
            var games = _playerRepository.GetAllTeams();
            var gamesToReturn = _mapper.Map<IEnumerable<GameDTO>>(games);
            return gamesToReturn;
        }

        public IEnumerable<PlayerDTO> GetAllPlayers()
        {
            var players = _playerRepository.GetAllPlayers();
            var playersToReturn = _mapper.Map<IEnumerable<PlayerDTO>>(players);
            return playersToReturn;
        }

        public IEnumerable<TeamDTO> GetAllTeams()
        {
            var teams = _playerRepository.GetAllTeams();
            var teamsToReturn = _mapper.Map<IEnumerable<TeamDTO>>(teams);
            return teamsToReturn;
        }

        public PlayerDTO GetPlayerById(int PlayerId)
        {
            var player = _playerRepository.GetPlayerById(PlayerId);
            var playerToReturn = _mapper.Map<PlayerDTO>(player);
            return playerToReturn;
        }

        public IEnumerable<PlayerDTO> GetPlayersByTeam(string TeamName)
        {
            var players = _playerRepository.GetPlayersByTeamName(TeamName);
            var playersToReturn = _mapper.Map<IEnumerable<PlayerDTO>>(players);
            return playersToReturn;
        }
        public void AddGame(GameDTO Game)
        {
            throw new NotImplementedException();
        }

        public void AddPlayer(PlayerDTO Player)
        {
            try
            {
                var team = _playerRepository.GetTeamById(Player.TeamId);
                Stat stats = new Stat()
                {
                    Height = Player.Stats.Height,
                    Weight = Player.Stats.Weight,
                    PPG = Player.Stats.PPG,
                    RPG = Player.Stats.RPG,
                    APG = Player.Stats.APG,
                    PIE = Player.Stats.PIE,
                    Assists = Player.Stats.Assists,
                    Score = Player.Stats.Score, 
                };
                Player player = new Player()
                {
                     Name = Player.Name,
                     LastName = Player.LastName,
                     Number = Player.Number,
                     ImageProfilePath = Player.ImageProfilePath,
                     Position = Player.Position,
                     Stats = stats,
                     BirthDate = Player.BirthDate,
                     Experience = Player.Experience,
                     Team = team
                };
                _playerRepository.AddPlayer(player);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddTeam(TeamDTO Team)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGame(int GameId)
        {
            if (GameId <= 0)
            {
                return false;
            }

            var game = _playerRepository.GetGameById(GameId);

            if (game == null)
            {
                throw new ApplicationException("Game not found");
            }

            try
            {
                return _playerRepository.DeleteGame(GameId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePlayer(int PlayerId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTeam(int TeamId)
        {
            throw new NotImplementedException();
        }

        public PlayerDTO EditGame(int GameID, GameDTO UpdatedGame)
        {
            throw new NotImplementedException();
        }

        public PlayerDTO EditPlayer(int PlayerId, PlayerDTO UpdatedPlayer)
        {
            throw new NotImplementedException();
        }

        public PlayerDTO EditTeam(int TeamID, TeamDTO UpdatedPlayer)
        {
            throw new NotImplementedException();
        }

        
    }
}
