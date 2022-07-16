namespace MapEntitiesService.Core.Configuration;

public class MapEntitiesSettings : IMapEntitiesSettings
{
    public string HostName { get; set; } = "";
    public string MapEntityTopic { get; set; } = "";
}