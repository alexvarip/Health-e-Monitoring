using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Patient_Vital_Signs_Monitoring.Hubs
{
    public class VitalsHub : Hub
    {
        private readonly ILogger<VitalsHub> _logger;

        public VitalsHub(ILogger<VitalsHub> logger)
        {
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation("SignalR client connected: {ConnectionId}", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation("SignalR client disconnected: {ConnectionId}", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
