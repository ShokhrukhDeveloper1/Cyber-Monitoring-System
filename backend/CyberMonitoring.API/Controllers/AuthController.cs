using CyberMonitoring.API.Data;
using CyberMonitoring.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CyberMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISecurityLogService _logService;

        public AuthController(AppDbContext context, IConfiguration config, ISecurityLogService logService)
        {
            _context = context;
            _config = config;
            _logService = logService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            if (user == null)
            {
                await _logService.LogAsync(
                    "LOGIN_FAILED",
                    "Invalid username or password",
                    username,
                    HttpContext.Connection.RemoteIpAddress?.ToString()
                );

                return Unauthorized("Invalid credentials");
            }

            await _logService.LogAsync(
                "LOGIN_SUCCESS",
                "User logged in successfully",
                user.Username,
                HttpContext.Connection.RemoteIpAddress?.ToString()
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}