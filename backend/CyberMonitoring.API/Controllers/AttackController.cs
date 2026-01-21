using CyberMonitoring.API.Data;
using CyberMonitoring.API.Models;
using Microsoft.AspNetCore.Mvc;
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
            _context.AttackLogs.Add(attack);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAttacks), new { id = attack.Id }, attack);
        }
    }
}
