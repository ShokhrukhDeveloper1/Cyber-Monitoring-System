using System;

namespace CyberMonitoring.API.Models
{
    public class SecurityLog
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string IPAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
