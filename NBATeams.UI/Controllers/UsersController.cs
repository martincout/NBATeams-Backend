using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBATeams.Data.Data;
using NBATeams.Data.Models;

namespace Petfy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly NBATeamsDbContext _context;

        public UsersController(NBATeamsDbContext context)
        {
            _context = context;
        }

        //Get
        //GetUsers
        //[Authorize(Policy = "RequireAdminRole")]
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        //Get
        //GetUserById
        [Authorize(Roles = "Admin, Owner")]
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return Ok(_context.Users.Find(id));
        }
    }
}
