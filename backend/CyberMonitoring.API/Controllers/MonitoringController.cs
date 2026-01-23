using CyberMonitoring.API.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CyberMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoringController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MonitoringController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/monitoring/summary
        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            var totalAttacks = _context.AttackLogs.Count();
            var blockedAttacks = _context.AttackLogs.Count(a => a.IsBlocked);
            var last24Hours = _context.AttackLogs
                .Count(a => a.DetectedAt >= DateTime.UtcNow.AddHours(-24));

            return Ok(new
            {
                TotalAttacks = totalAttacks,
                BlockedAttacks = blockedAttacks,
                AttacksLast24Hours = last24Hours
            });
        }

        // GET: api/monitoring/recent-attacks
        [HttpGet("recent-attacks")]
        public IActionResult GetRecentAttacks()
        {
            var recentAttacks = _context.AttackLogs
                .OrderByDescending(a => a.DetectedAt)
                .Take(5)
                .Select(a => new
                {
                    a.AttackType,
                    a.IpAddress,
                    a.DetectedAt,
                    a.IsBlocked
                })
                .ToList();

            return Ok(recentAttacks);
        }
    }
}
