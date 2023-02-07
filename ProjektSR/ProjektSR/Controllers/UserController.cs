using Microsoft.AspNetCore.Mvc;
using ProjektSR.Interfaces;
using ProjektSR.Models;

namespace ProjektSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            return Ok(user);
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
