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

        public TeamsController(IPlayerService context)
        {
            _playerService = context;
        }

        // GET: api/Teams
        [HttpGet]
        public ActionResult<IEnumerable<TeamDTO>> GetTeams()
        {
          if (_playerService.GetAllTeams() == null)
          {
              return NotFound();
          }
            return Ok(_playerService.GetAllTeams());
        }

        // GET: api/Teams
        [HttpGet("teamsaddplayer")]
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
        public ActionResult<Team> GetTeam(int id)
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
        [HttpPost]
        public ActionResult<TeamDTO> PostTeam(TeamDTO team)
        {
          if (_playerService == null)
          {
              return Problem("Entity set 'NBATeamsDbContext'  is null.");
          }
            _playerService.AddTeam(team);

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
    }
}
