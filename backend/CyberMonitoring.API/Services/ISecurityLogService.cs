using System.Threading.Tasks;

namespace CyberMonitoring.API.Services
{
    public interface ISecurityLogService
    {
        Task LogAsync(
            string eventType,
            string message,
            string username,
            string ipAddress
        );
    }
}