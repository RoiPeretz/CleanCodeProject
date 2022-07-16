using MapEntitiesService.Core.Configuration;
using MapEntitiesService.Core.Models;
using MapEntitiesService.Core.Services.Interfaces;
using MessageBroker.Core.Interfaces;

namespace MapEntitiesService.Core.Services;

public class MapEntityService : IMapEntityService
{
    private readonly IPublisher _publisher;
    private readonly IMapEntitiesSettings _settings;
    
    public MapEntityService(IPublisher publisher, IMapEntitiesSettings settings)
    {
        _publisher = publisher;
        _settings = settings;
    }
    
    public bool AddMapEntity(MapEntity mapEntity)
    {
        
        var message = $"{mapEntity.Title} {mapEntity.XPosition} {mapEntity.YPosition}";
        _publisher.Publish(_settings.MapEntityTopic, message);
        
        //Todo Change to result model
        return true;
    }
}