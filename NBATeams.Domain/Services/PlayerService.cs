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

        public IEnumerable<Team> GetAllTeams()
        {
            var teams = _playerRepository.GetAllTeams();
            return teams;
        }

        public IEnumerable<TeamRegisterPlayerDTO> GetAllTeamsAddPlayer()
        {
            var teams = _playerRepository.GetAllOfficialTeams();
            var teamsToReturn = _mapper.Map<IEnumerable<TeamRegisterPlayerDTO>>(teams);
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
                    PPG = Player.Stats.PPG,
                    RPG = Player.Stats.RPG,
                    APG = Player.Stats.APG,
                    PIE = Player.Stats.PIE,
                    Assists = Player.Stats.Assists
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
                     Team = (OfficialTeam) team,
                     Height = Player.Height,
                     Weight = Player.Weight,
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

        public Game EditGame(int GameID, GameDTO UpdatedGame)
        {
            throw new NotImplementedException();
        }

        public Player EditPlayer(int PlayerId, PlayerDTO UpdatedPlayer)
        {
            var oldPlayer = _playerRepository.GetPlayerById(PlayerId);
            if (oldPlayer != null)
            {
                //Stats
                oldPlayer.Height = UpdatedPlayer.Height;
                oldPlayer.Weight = UpdatedPlayer.Weight;
                oldPlayer.Stats.PPG = UpdatedPlayer.Stats.PPG;
                oldPlayer.Stats.RPG = UpdatedPlayer.Stats.RPG;
                oldPlayer.Stats.APG = UpdatedPlayer.Stats.APG;
                oldPlayer.Stats.PIE = UpdatedPlayer.Stats.PIE;
                oldPlayer.Stats.Assists = UpdatedPlayer.Stats.Assists;
                //Team
                OfficialTeam team = _playerRepository.GetOfficialTeamById(UpdatedPlayer.TeamId);
                //Player
                oldPlayer.ImageProfilePath = UpdatedPlayer.ImageProfilePath;
                oldPlayer.Name = UpdatedPlayer.Name;
                oldPlayer.LastName = UpdatedPlayer.LastName;
                oldPlayer.Number = UpdatedPlayer.Number;
                oldPlayer.BirthDate = UpdatedPlayer.BirthDate;
                oldPlayer.Experience = UpdatedPlayer.Experience;
                oldPlayer.Position = UpdatedPlayer.Position;
                oldPlayer.Team = team;
                return _playerRepository.EditPlayer(oldPlayer);

            }
            return null;
        }

        public OfficialTeam EditTeam(int TeamID, TeamDTO UpdatedTeam)
        {
            var oldTeam = _playerRepository.GetOfficialTeamById(TeamID);
            if (oldTeam != null)
            {
                Court court = _playerRepository.GetOfficialTeamById(TeamID).Court;
                court.Name = UpdatedTeam.Court.Name;
                oldTeam.Name = UpdatedTeam.Name;
                oldTeam.Court = court;
                //Team
                return _playerRepository.EditCustomTeam(oldTeam);

            }
            return null;
        }

        public TeamDTO GetTeamById(int TeamId)
        {
            var team = _playerRepository.GetTeamById(TeamId);
            var teamToReturn = _mapper.Map<TeamDTO>(team);
            return teamToReturn;
        }

        public IEnumerable<CustomTeamDTO> GetAllCustomTeams()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfficialTeam> GetAllOfficialTeams()
        {
            var teams = _playerRepository.GetAllOfficialTeams();
            return teams;
        }

      
        Team IPlayerService.EditTeam(int TeamID, TeamDTO UpdatedTeam)
        {
            throw new NotImplementedException();
        }

        public CustomTeam EditTeam(int TeamID, CustomTeamDTO UpdatedTeam)
        {
            throw new NotImplementedException();
        }

        public OfficialTeam EditTeam(int TeamID, OfficialTeam UpdatedTeam)
        {
            throw new NotImplementedException();
        }
    }
}
