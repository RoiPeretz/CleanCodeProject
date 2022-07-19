using Microsoft.AspNetCore.SignalR;
using NotificationService.Hubs;

namespace NotificationService.Commands.NewMapEntity;

internal class NewMapEntityCommandHandler : INewMapEntityCommandHandler
{
    private readonly IHubContext<MapEntityNotificationHub> _hubContext;
    private readonly ILogger<Worker> _logger;

    public NewMapEntityCommandHandler(
        IHubContext<MapEntityNotificationHub> hubContext,
        ILogger<Worker> logger)
    {
        _hubContext = hubContext;
        _logger = logger;
    }

    public void OnNewMapEntity(string message)
    {
        _logger.LogInformation("Received new entity - {entity} from message broker", message);
        _hubContext.Clients.All.SendAsync("", message);
    }
}