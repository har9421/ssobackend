using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSO.Application.Abstractions.DataAbstractions;
using SSO.Application.Service;
using SSO.Application.ViewModel;
using SSO.Domain;

namespace SSO.API.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserVM user)
        {
            var result = await _userService.Login(user);
            if (result.Equals("Login Failed"))
                return new BadRequestResult();

            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserVM user)
        {
            await _userService.RegisterUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("check")]
        public async Task<IActionResult> Check()
        {
            return Ok("Working");
        }
    }
}
