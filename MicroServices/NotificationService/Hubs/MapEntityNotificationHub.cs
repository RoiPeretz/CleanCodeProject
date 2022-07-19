using Microsoft.AspNetCore.SignalR;

namespace NotificationService.Hubs;

public class MapEntityNotificationHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
}