using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBATeams.Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NBATeams.Domain.Services;

namespace NBATeams.UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        //GET api/Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> GetTeams()
        {
            var teams = _playerService.GetAllTeams();
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        //Get api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetPlayers()
        {
            var players = _playerService.GetByName();
            if (players == null)
            {
                return NotFound();
            }
            return players;
        }

        //PUT api/Player/number
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, PlayerDTO player)
        {
            try
            {
                _playerService.EditPlayer(id, player)
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }

        //POST: api/Player
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(PlayerDTO player)
        {
            var players = _playerService.GetAllPlayers();
            if (players == null)
            {
                return Problem("Entity set 'PlayerDbContext.Players' is null.");
            }
            try
            {
                _playerService.AddPlayer(player);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(player)
        }

        //DELETE: api/Player/number
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var players = _playerService.GetAllPlayers();
            if (players == null)
            {
                return NotFound();
            }
            try
            {
                var deleteflag = _petService.DeletePet(id);
                if (!deleteflag)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }
    }

}
