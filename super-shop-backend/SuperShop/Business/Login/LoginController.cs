using SuperShop.Authentication.Jwt;
using SuperShop.Business.Login.Services;
using SuperShop.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SuperShop.Business.Login
{
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtGeneration _jwtGeneration;
        public LoginController(UserService userService, JwtGeneration jwtGeneration)
        {
            _userService = userService;
            _jwtGeneration = jwtGeneration;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Login([FromQuery] string email)
        {
            var payload = new Dictionary<string, string>
            {
                {"clientId", email}
            };
            var token = _jwtGeneration.GenerateJwt(payload);
            var l = await _userService.AddLogin(email);
            var login = new
            {
                email = l.Email,
                isAdmin = l.IsAdmin,
                token = token
            };
            return Ok(login);
        }

        [HttpGet]
        [Route("api/[controller]/users")]
        [Authorize]
        public async Task<IActionResult> getUsers()
        {
            return Ok(await _userService.GetUsers());
        }
    }
}
