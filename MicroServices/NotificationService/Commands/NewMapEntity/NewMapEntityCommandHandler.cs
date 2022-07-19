using Microsoft.AspNetCore.SignalR;
using NotificationService.Configuration;
using NotificationService.Hubs;

namespace NotificationService.Commands.NewMapEntity;

internal class NewMapEntityCommandHandler : INewMapEntityCommandHandler
{
    private readonly IHubContext<MapEntityNotificationHub> _hubContext;
    private readonly INotificationServiceSettings _settings;
    private readonly ILogger<Worker> _logger;

    public NewMapEntityCommandHandler(
        IHubContext<MapEntityNotificationHub> hubContext,
        INotificationServiceSettings settings,
        ILogger<Worker> logger)
    {
        _hubContext = hubContext;
        _settings = settings;
        _logger = logger;
    }

    public void OnNewMapEntity(string message)
    {
        _logger.LogInformation("Received new entity - {entity} from message broker", message);
        _hubContext.Clients.All.SendAsync(_settings.GetNewMapEntityClientMethod, "", message);
    }
}