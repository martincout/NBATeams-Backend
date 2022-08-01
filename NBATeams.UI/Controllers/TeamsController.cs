using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBATeams.Data.Data;
using NBATeams.Data.Models;
using NBATeams.Domain.DTOs;
using NBATeams.Domain.Services;

namespace NBATeams.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;

        public TeamsController(IPlayerService context, IGameService gameSer)
        {
            _playerService = context;
            _gameService = gameSer;
        }

        // GET: api/Teams
        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetTeams()
        {
            if (_playerService.GetAllOfficialTeams() == null)
            {
                return NotFound();
            }
            return Ok(_playerService.GetAllOfficialTeams());
        }

        // GET: api/Teams
        [HttpGet("officialteams")]
        public ActionResult<IEnumerable<OfficialTeam>> GetOfficialTeams()
        {
            if (_playerService.GetAllOfficialTeams() == null)
            {
                return NotFound();
            }
            return Ok(_playerService.GetAllOfficialTeams());
        }

        // GET: api/Teams
        [HttpGet("customteams")]
        public ActionResult<IEnumerable<CustomTeamDTO>> GetCustomTeams()
        {
            if (_playerService.GetAllCustomTeams() == null)
            {
                return NotFound();
            }
            return Ok(_playerService.GetAllCustomTeams());
        }

        // GET: api/Teams
        [HttpGet("name&id")]
        public ActionResult<IEnumerable<TeamRegisterPlayerDTO>> GetTeamsAddPlayer()
        {
            if (_playerService.GetAllTeams() == null)
            {
                return NotFound();
            }
            return Ok(_playerService.GetAllTeamsAddPlayer());
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public ActionResult<OfficialTeam> GetTeam(int id)
        {
          if (_playerService.GetTeamById(id)== null)
          {
              return NotFound();
          }
            var team = _playerService.GetTeamById(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutTeam(int id, TeamDTO team)
        {
            if (_playerService.GetTeamById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_playerService.EditTeam(id, team));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("officialteam")]
        public ActionResult<OfficialTeam> PostOfficialTeam(OfficialTeamDTO team)
        {
            if (_playerService == null)
            {
                return Problem("Entity set 'NBATeamsDbContext'  is null.");
            }
            _playerService.AddOfficialTeam(team);

            return CreatedAtAction("GetTeam", team);
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("customteam")]
        public ActionResult<TeamDTO> PostCustomTeam(CustomTeamDTO team)
        {
            if (_playerService == null)
            {
                return Problem("Entity set 'NBATeamsDbContext'  is null.");
            }
            _playerService.AddCustomTeam(team);

            return CreatedAtAction("GetTeam", team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            if (_playerService.GetTeamById(id) == null)
            {
                return NotFound();
            }
            var team = _playerService.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(_playerService.DeleteTeam(id));
        }

        private bool TeamExists(int id)
        {
            return (_playerService.GetTeamById(id) != null);
        }

        [HttpGet("match")]
        public ActionResult<Team> Match(int teamLocalId, int teamVisitId)
        {
            return Ok(_gameService.MatchTwoTeams(teamLocalId, teamVisitId));
        }
    }
}
