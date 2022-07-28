﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: api/Players
        [HttpGet]
        public  ActionResult<IEnumerable<Player>> GetPlayers()
        {
          if (_playerService.GetAllPlayers() == null)
          {
              return NotFound();
          }
            return Ok(_playerService.GetAllPlayers());
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public ActionResult<Player> GetPlayer(int id)
        {
          if (_playerService.GetAllPlayers() == null)
          {
              return NotFound();
          }
            var player = _playerService.GetPlayerById(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutPlayer(int id, PlayerDTO player)
        {
            if (_playerService.GetPlayerById(id) == null)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_playerService.EditPlayer(id,player));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(PlayerDTO player)
        {
          if (_playerService == null)
          {
              return Problem("Entity set 'NBATeamsDbContext.Players'  is null.");
          }
            _playerService.AddPlayer(player);

            return CreatedAtAction("GetPlayer", player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            if (_playerService.GetAllPlayers() == null)
            {
                return NotFound();
            }

            return Ok(_playerService.DeletePlayer(id));

        }

        [HttpGet ("playername")]
        public ActionResult<IEnumerable<Player>> GetPlayersByName(string playername)
        {
            if(String.IsNullOrEmpty(playername) || Regex.IsMatch(playername, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine(playername);
                return BadRequest(string.Empty);
            }

            return Ok(_playerService.getPlayersByName(playername));
        }

        [HttpGet("teamname")]
        public ActionResult<IEnumerable<Player>> GetPlayersByTeamName(string teamname)
        {
            if (String.IsNullOrEmpty(teamname) || Regex.IsMatch(teamname, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine(teamname);
                return BadRequest(string.Empty);
            }

            return Ok(_playerService.GetPlayersByTeam(teamname));
        }
        private bool PlayerExists(int id)
        {
            return (_playerService.GetPlayerById(id) != null);
        }
    }
}
