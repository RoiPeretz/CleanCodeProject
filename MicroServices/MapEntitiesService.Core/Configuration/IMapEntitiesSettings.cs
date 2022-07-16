namespace MapEntitiesService.Core.Configuration;

public interface IMapEntitiesSettings
{
    string HostName { get; set; }
    string MapEntityTopic { get; set; }
}