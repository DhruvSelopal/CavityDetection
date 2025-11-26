using CavityDetection.models.dtos;
using CavityDetection.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CavityDetection.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            if (_userService.UserExists(dto.Username))
                return Conflict("User already exists");

            var created = _userService.CreateUser(dto);

            return Ok(created);
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (_userService.Login(login))
                return Ok("Login successful");

            return Unauthorized("Invalid username or password");
        }

        [HttpPost]
        public IActionResult UpdateUser(UserUpdate update)
        {
            _userService.UpdateUser(update);
            return Ok("User updated");
        }

        [HttpGet]
        public IActionResult GetAllRecord(string username)
        {
            var records = _userService.GetAllRecord(username);
            return Ok(records);
        }

        [HttpGet]
        public IActionResult UserExists(string username)
        {
            return Ok(_userService.UserExists(username));
        }
    }

}
