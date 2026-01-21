using CyberMonitoring.API.Data;
using CyberMonitoring.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CyberMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/alerts
        [HttpGet]
        public ActionResult<IEnumerable<Alert>> GetAlerts()
        {
            return Ok(_context.Alerts.ToList());
        }
    }
}