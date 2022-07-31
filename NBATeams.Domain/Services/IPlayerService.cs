using NBATeams.Data.Models;
using NBATeams.Domain.DTOs;

namespace NBATeams.Domain.Services
{
    public interface IPlayerService
    {
        public IEnumerable<PlayerDTO> GetAllPlayers();

        public IEnumerable<Team> GetAllTeams();

        public IEnumerable<CustomTeam> GetAllCustomTeams();

        public IEnumerable<OfficialTeam> GetAllOfficialTeams();

        public IEnumerable<GameDTO> GetAllGames();

        public IEnumerable<TeamRegisterPlayerDTO> GetAllTeamsAddPlayer();

        public OfficialTeam GetOfficialTeamById(int id);

        public CustomTeam GetCustomTeamById(int id);

        public IEnumerable<PlayerDTO> GetPlayersByTeam(string TeamName);

        public PlayerDTO GetPlayerById(int PlayerId);

        public TeamDTO GetTeamById(int TeamId);

        public void AddPlayer(PlayerDTO Player);

        public void AddTeam(TeamDTO Team);

        public void AddOfficialTeam(OfficialTeamDTO Team);

        public void AddCustomTeam(CustomTeamDTO Team);

        public void AddGame(GameDTO Game);

        public Player EditPlayer(int PlayerId, PlayerDTO UpdatedPlayer);

        public Team EditTeam(int TeamID, TeamDTO UpdatedTeam);
        
        public CustomTeam EditTeam(int TeamID, CustomTeamDTO UpdatedTeam);

        public OfficialTeam EditTeam(int TeamID, OfficialTeam UpdatedTeam);

        public Game EditGame(int GameID, GameDTO UpdatedGame);

        public bool DeletePlayer(int PlayerId);

        public bool DeleteTeam(int TeamId);

        public bool DeleteGame(int GameId);
    }
}
