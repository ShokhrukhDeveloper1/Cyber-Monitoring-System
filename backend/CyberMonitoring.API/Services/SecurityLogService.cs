using CyberMonitoring.API.Data;
using CyberMonitoring.API.Models;
using System;
using System.Threading.Tasks;

namespace CyberMonitoring.API.Services
{
    public class SecurityLogService : ISecurityLogService
    {
        private readonly AppDbContext _context;

        public SecurityLogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(string eventType, string message, string username, string ipAddress)
        {
            var log = new SecurityLog
            {
                EventType = eventType,
                Message = message,
                Username = username,
                IPAddress = ipAddress,
                CreatedAt = DateTime.UtcNow
            };

            _context.SecurityLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}