using ExceptionsVsDomainNotification.NotificationApi.Extensions;
using ExceptionsVsDomainNotification.NotificationApi.Models;
using ExceptionsVsDomainNotification.NotificationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionsVsDomainNotification.NotificationApi.Controllers
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

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userRequest">asdas</param>
        /// <returns>asda</returns>
        [HttpPost("login")]
        public IActionResult Login(UserRequest userRequest)
        {
            var user = _userService.Login(userRequest);

            return user.MatchResponse();
        }
    }
}