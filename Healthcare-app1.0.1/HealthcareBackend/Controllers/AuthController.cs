using Microsoft.AspNetCore.Mvc;
using HealthcareBackend.Data;
using HealthcareBackend.Models;
using HealthcareBackend.Services;

namespace HealthcareBackend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HealthcareDbContext _context;
        private readonly AuthService _authService;

        public AuthController(HealthcareDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.Authenticate(request.Username, request.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
