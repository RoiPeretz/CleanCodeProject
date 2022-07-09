using MapEntitiesService.Core.Services.Interfaces;
using MessageBroker.Core;

namespace MapEntitiesService.Core.Services;

public class MapEntityService : IMapEntityService
{
    private readonly IPublisher _publisher;

    public MapEntityService(IPublisher publisher)
    {
        _publisher = publisher;
    }
    
    public bool AddMapEntity(Core.Models.MapEntity mapEntity)
    {
        var message = $"{mapEntity.Title} {mapEntity.XPosition} {mapEntity.YPosition}";
        _publisher.Publish("AddedMapEntity", message);
        return true;
    }
}
