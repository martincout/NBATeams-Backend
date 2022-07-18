using NBATeams.Data.Data;
using NBATeams.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly NBATeamsDbContext _context;

        public PlayerRepository(NBATeamsDbContext context)
        {
            _context = context;
        }

        public void AddGame(Game Game)
        {
            if (Game != null)
            {
                try
                {
                    _context.Games.Add(Game);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void AddPlayer(Player Player)
        {
            if (Player != null)
            {
                try
                {
                    _context.Players.Add(Player);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void AddTeam(Team Team)
        {
            if (Team != null)
            {
                try
                {
                    _context.Teams.Add(Team);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool DeleteGame(int GameId)
        {
            Game game = _context.Games.Find(GameId);
            if (game != null)
            {
                try
                {
                    _context.Games.Remove(game);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            return false;
        }

        public bool DeletePlayer(int PlayerId)
        {
            Player player = _context.Players.Find(PlayerId);
            if (player != null)
            {
                try
                {
                    _context.Players.Remove(player);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            return false;
        }

        public bool DeleteTeam(int TeamId)
        {
            Team team = _context.Teams.Find(TeamId);
            if (team != null)
            {
                try
                {
                    _context.Teams.Remove(team);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            return false;
        }

        public Game EditGame(int GameID, Game UpdatedGame)
        {
            try
            {
                _context.Update(UpdatedGame);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return UpdatedGame;
        }

        public Player EditPlayer(int PlayerId, Player UpdatedPlayer)
        {
            try
            {
                _context.Update(UpdatedPlayer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return UpdatedPlayer;
        }

        public Team EditTeam(int TeamID, Team UpdatedTeam)
        {
            try
            {
                _context.Update(UpdatedTeam);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return UpdatedTeam;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Players;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams;
        }

        public Team GetTeamById(int TeamId)
        {
            return _context.Teams.Find(TeamId);
        }

        public Player GetPlayerById(int PlayerId)
        {
            return _context.Players.Find(PlayerId);
        }

        public IEnumerable<Player> GetPlayersByTeamName(string TeamName)
        {
            return _context.Players.Where(x => x.Team.Name == TeamName);
        }

        public Game GetGameById(int id)
        {
            return _context.Games.Find(id);
        }
    }
}
