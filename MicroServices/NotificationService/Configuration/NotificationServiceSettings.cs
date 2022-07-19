namespace NotificationService.Configuration;

public class NotificationServiceSettings : INotificationServiceSettings
{
    public string HostName { get; set; } = "";
    public string MapEntityTopic { get; set; } = "";
    public string GetNewMapEntityClientMethod { get; set; }
}