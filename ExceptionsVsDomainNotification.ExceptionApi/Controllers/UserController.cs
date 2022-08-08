using ExceptionsVsDomainNotification.ExceptionApi.Models;
using ExceptionsVsDomainNotification.ExceptionApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionsVsDomainNotification.ExceptionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("login")]        
        public IActionResult Login(UserRequest userRequest)
        {
            var user = _userService.Login(userRequest);

            return Ok(user);
        }
    }
}