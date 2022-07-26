namespace MapRepositoryService.Core.Configuration;

public interface IMapsSettings
{
    string HostName { get; set; }
    string MapTopic { get; set; }
}