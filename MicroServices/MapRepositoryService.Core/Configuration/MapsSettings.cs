namespace MapRepositoryService.Core.Configuration;

public class MapsSettings : IMapsSettings
{
    public string HostName { get; set; } = "";
    public string MapTopic { get; set; } = "";
}