using Microsoft.AspNetCore.Mvc;
using ProjektSR.Interfaces;
using ProjektSR.Models;
using System.Text.Json.Serialization;

namespace ProjektSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public UserController(IUserRepository userRepository,
            ITokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var result = _userRepository.CreateUser(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredential userCredential)
        {
            var user = _userRepository.GetUserByCredentials(userCredential);
            if (user is null) return Unauthorized();
            var authenticatedResponse = new AuthenticatedResponse
            {
                Token = _tokenRepository.CreateToken(user)
            };
            return Ok(authenticatedResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetuserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user is null) return BadRequest("User does not exist!");
            return Ok(user);
        }
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var result = _userRepository.DeleteUser(id);
            if (!result) return BadRequest("User cannot be found");
            return Ok();
        }
    }

}
