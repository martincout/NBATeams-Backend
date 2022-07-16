using NBATeams.Data.Models;
using NBATeams.Domain.DTOs;

namespace NBATeams.Domain.Services
{
    public interface IPlayerService
    {
        public IEnumerable<PlayerDTO> GetAllPlayers();

        public IEnumerable<TeamDTO> GetAllTeams();

        public IEnumerable<GameDTO> GetAllGames();

        public IEnumerable<PlayerDTO> GetPlayersByTeam(string TeamName);

        public PlayerDTO GetPlayerById(int PlayerId);

        public void AddPlayer(PlayerDTO Player);

        public void AddTeam(TeamDTO Team);

        public void AddGame(GameDTO Game);

        public PlayerDTO EditPlayer(int PlayerId, PlayerDTO UpdatedPlayer);

        public PlayerDTO EditTeam(int TeamID, TeamDTO UpdatedPlayer);

        public PlayerDTO EditGame(int GameID, GameDTO UpdatedGame);

        public bool DeletePlayer(int PlayerId);

        public bool DeleteTeam(int TeamId);

        public bool DeleteGame(int GameId);
    }
}
