using CyberMonitoring.API.Data;
using CyberMonitoring.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AttackController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/attacks
        [HttpGet]
        public ActionResult<IEnumerable<AttackLog>> GetAttacks()
        {
            return Ok(_context.AttackLogs.ToList());
        }

        // POST: api/attacks
        [HttpPost]
        public ActionResult<AttackLog> CreateAttack([FromBody] AttackLog attack)
        {
            var oneMinuteAgo = DateTime.UtcNow.AddMinutes(-1);

            int attackCount = _context.AttackLogs
                .Count(a => a.IpAddress == attack.IpAddress && a.DetectedAt >= oneMinuteAgo);

            if (attackCount >= 3)
            {
                attack.IsBlocked = true;

                var alert = new Alert
                {
                    Message = $"Shubhali faoliyat aniqlandi. IP: {attack.IpAddress}",
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                };

                _context.Alerts.Add(alert);
            }

            _context.AttackLogs.Add(attack);
            _context.SaveChanges();

            return Ok(attack);
        }
    }
}
