using System;

namespace CyberMonitoring.API.Models
{
    public class AttackLog
    {
        public int Id { get; set; }
        public string AttackType { get; set; }
        public string IpAddress { get; set; }
        public DateTime DetectedAt { get; set; } = DateTime.UtcNow;
        public bool IsBlocked { get; set; }
    }
}
