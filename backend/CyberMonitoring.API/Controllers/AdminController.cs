using CyberMonitoring.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly ISecurityLogService _logService;

    public AdminController(ISecurityLogService logService)
    {
        _logService = logService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        await _logService.LogAsync(
            "ADMIN_ACCESS",
            "Admin dashboard accessed",
            User.Identity.Name,
            HttpContext.Connection.RemoteIpAddress?.ToString()
        );

        return Ok("Welcome Admin! This endpoint is protected.");
    }
}