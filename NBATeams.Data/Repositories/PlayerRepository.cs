using Microsoft.EntityFrameworkCore;
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

        public void AddTeam(OfficialTeam Team)
        {
            if (Team != null)
            {
                try
                {
                    _context.OfficialTeams.Add(Team);
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
            OfficialTeam team = _context.OfficialTeams.Find(TeamId);
            if (team != null)
            {
                try
                {
                    _context.OfficialTeams.Remove(team);
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

        public Game EditGame(Game UpdatedGame)
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

        public Player EditPlayer(Player UpdatedPlayer)
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

        public Team EditTeam(Team UpdatedTeam)
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
            return _context.Players.Include(p => p.Stats);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams;
        }

        public IEnumerable<OfficialTeam> GetAllOfficialTeams()
        {
            return _context.OfficialTeams;
        }

        public IEnumerable<CustomTeam> GetAllCustomTeams()
        {
            return _context.CustomTeams;
        }

        public Team GetTeamById(int TeamId)
        {
            return _context.Teams
                .FirstOrDefault(x => x.Id == TeamId);
        }
        public CustomTeam GetCustomTeamById(int TeamId)
        {
            return _context.CustomTeams
                .FirstOrDefault(x => x.Id == TeamId);
        }
        public OfficialTeam GetOfficialTeamById(int TeamId)
        {
            return _context.OfficialTeams
                .FirstOrDefault(x => x.Id == TeamId);
        }
        /// <summary>
        /// Returns Player including stats
        /// </summary>
        /// <param name="PlayerId"></param>
        /// <returns>Player with Stats</returns>
        public Player GetPlayerById(int PlayerId)
        {
            return _context.Players.Include(p => p.Stats)
                .FirstOrDefault(p => p.Id == PlayerId);
        }

        public IEnumerable<Player> GetPlayersByTeamName(string TeamName)
        {
            return _context.Players.Where(x => x.Team.Name == TeamName);
        }

        public Game GetGameById(int id)
        {
            return _context.Games.Find(id);
        }

        public Team EditCustomTeam(CustomTeam UpdatedTeam)
        {
            throw new NotImplementedException();
        }

        public Team EditOfficialTeam(OfficialTeam UpdatedTeam)
        {
            throw new NotImplementedException();
        }

        public OfficialTeam EditCustomTeam(OfficialTeam oldTeam)
        {
            throw new NotImplementedException();
        }

        CustomTeam IPlayerRepository.EditCustomTeam(CustomTeam UpdatedTeam)
        {
            throw new NotImplementedException();
        }

        OfficialTeam IPlayerRepository.EditOfficialTeam(OfficialTeam UpdatedTeam)
        {
            throw new NotImplementedException();
        }

        public void AddTeam(Team Team)
        {
            throw new NotImplementedException();
        }

        public void AddOfficialTeam(OfficialTeam officialTeam, Team team)
        {
            if (officialTeam != null && team != null)
            {
                try
                {
                    _context.Teams.Add(team);
                    _context.OfficialTeams.Add(officialTeam);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void AddCustomTeam(CustomTeam customTeam, Team team)
        {
            if (customTeam != null && team != null)
            {
                try
                {
                    _context.Teams.Add(team);
                    _context.CustomTeams.Add(customTeam);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
