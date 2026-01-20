using Microsoft.AspNetCore.Mvc;

namespace CyberMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Backend is running (Classic .NET 5)!");
        }
    }
}
