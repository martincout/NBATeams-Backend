using NBATeams.Data.Models;
using NBATeams.Domain.DTOs;

namespace NBATeams.Domain.Services
{
    public interface IPlayerService
    {
        public IEnumerable<PlayerDTO> GetAllPlayers();

        public IEnumerable<TeamDTO> GetAllTeams();

        public IEnumerable<GameDTO> GetAllGames();

        public IEnumerable<TeamRegisterPlayerDTO> GetAllTeamsAddPlayer();

        public IEnumerable<PlayerDTO> GetPlayersByTeam(string TeamName);

        public PlayerDTO GetPlayerById(int PlayerId);


        public TeamDTO GetTeamById(int TeamId);

        public void AddPlayer(PlayerDTO Player);

        public void AddTeam(TeamDTO Team);

        public void AddGame(GameDTO Game);

        public Player EditPlayer(int PlayerId, PlayerDTO UpdatedPlayer);

        public Team EditTeam(int TeamID, TeamDTO UpdatedTeam);

        public Game EditGame(int GameID, GameDTO UpdatedGame);

        public bool DeletePlayer(int PlayerId);

        public bool DeleteTeam(int TeamId);

        public bool DeleteGame(int GameId);
    }
}
