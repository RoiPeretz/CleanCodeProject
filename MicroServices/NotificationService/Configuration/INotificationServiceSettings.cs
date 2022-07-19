namespace NotificationService.Configuration;

public interface INotificationServiceSettings
{
    string HostName { get; set; }
    string MapEntityTopic { get; set; }
}