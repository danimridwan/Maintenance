
using System.Net.NetworkInformation;
using Microsoft.JSInterop;
using Microsoft.Extensions.Logging;

namespace MaintenanceWebApp.Services
{
    public class NotificationService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(IJSRuntime jsRuntime, ILogger<NotificationService> logger)
        {
            _jsRuntime = jsRuntime;
            _logger = logger;
        }

        //Alert Notification
        public async Task AlertMessage(string message)
        {
            await _jsRuntime.InvokeVoidAsync("alert", message);
        }

        //Log Notification
        public void LogMessage(string message)
        {
            _logger.LogError(message);
        }
    }
}
