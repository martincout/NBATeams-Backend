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
            throw new NotImplementedException();
        }

        public IEnumerable<PlayerDTO> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamDTO> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public PlayerDTO GetPlayerById(int PlayerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayerDTO> GetPlayerByTeam(string TeamName)
        {
            throw new NotImplementedException();
        }
        public void AddGame(GameDTO Game)
        {
            throw new NotImplementedException();
        }

        public void AddPlayer(PlayerDTO Player)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(TeamDTO Team)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGame(int GameId)
        {
            throw new NotImplementedException();
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
