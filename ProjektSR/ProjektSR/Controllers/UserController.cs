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

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userRepository.CreateUser(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUser([FromQuery] UserCredential userCredential)
        {
            var user = _userRepository.GetUserByCredentials(userCredential);
            if (user is null) return BadRequest("User does not exist!");
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetuserById(int id)
        {
            var user = _userRepository.UserGetUserById(id);
            if (user is null) return BadRequest("User does not exist!");
            return Ok(user);
        }
    }

}
