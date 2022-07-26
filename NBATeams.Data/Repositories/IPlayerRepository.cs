using NBATeams.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Repositories
{
    public interface IPlayerRepository
    {
        public IEnumerable<Player> GetAllPlayers();

        public IEnumerable<Team> GetAllTeams();

        public IEnumerable<CustomTeam> GetAllCustomTeams();

        public IEnumerable<OfficialTeam> GetAllOfficialTeams();

        public IEnumerable<Game> GetAllGames();

        public IEnumerable<Player> GetPlayersByTeamName(string teamName);
        
        public Team GetTeamById(int id);
        
        public CustomTeam GetCustomTeamById(int id);

        public OfficialTeam GetOfficialTeamById(int id);

        public Game GetGameById(int id);

        public Player GetPlayerById(int PlayerId);

        public void AddPlayer(Player Player);

        public void AddTeam(Team Team);

        public void AddGame(Game Game);

        public Player EditPlayer(Player UpdatedPlayer);

        public Team EditTeam(Team UpdatedTeam);
        
        public CustomTeam EditCustomTeam(CustomTeam UpdatedTeam);

        public OfficialTeam EditOfficialTeam(OfficialTeam UpdatedTeam);
        
        public Game EditGame(Game UpdatedGame);

        public bool DeletePlayer(int PlayerId);

        public bool DeleteTeam(int TeamId);

        public bool DeleteGame(int GameId);
        OfficialTeam EditCustomTeam(OfficialTeam oldTeam);
    }
}
