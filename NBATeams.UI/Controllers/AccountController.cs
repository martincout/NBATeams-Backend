using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NBATeams.Data.Models;
using NBATeams.Domain.DTOs;
using NBATeams.Domain.Services;

namespace NBATeams.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(ITokenService tokenService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        //Post
        //login
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO login)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.UserName == login.Username);

            if (user == null) return Unauthorized("Username or password incorrect");

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded) return Unauthorized();

            var token = await _tokenService.CreateToken(user);

            var userDTO = _mapper.Map<UserDTO>(user);
            userDTO.Token = token;

            return Ok(userDTO);
        }

        //Post
        //register
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO user)
        {
            if (UserExists(user.Username)) return BadRequest("User already taken");

            var newUser = _mapper.Map<AppUser>(user);
            //var newUser = _mapper.Map<AppUser>(user);
            newUser.UserName = user.Username;

            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(newUser, "Owner");

            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            var token = await _tokenService.CreateToken(newUser);

            var ownerDTO = _mapper.Map<UserDTO>(newUser);
            ownerDTO.Token = token;

            return Ok(ownerDTO);
        }

        private bool UserExists(string username)
        {
            return _userManager.Users.Any(u => u.UserName == username);
        }
    }
}
