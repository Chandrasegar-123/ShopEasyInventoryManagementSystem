using Microsoft.AspNetCore.Mvc;
using ShopEasyIMS.DTOs;
using ShopEasyIMS.Services;

namespace ShopEasyIMS.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            var success = await _authService.RegisterUser(request);
            if (!success) return BadRequest("Username already exists.");
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var response = await _authService.LoginUser(request);
            if (response == null) return Unauthorized("Invalid credentials.");
            return Ok(response);
        }
    }
}
