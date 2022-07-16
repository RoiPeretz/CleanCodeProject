using MapEntitiesService.Core.Models;

namespace MapEntitiesService.Core.Services.Interfaces;

public interface IMapEntityService
{
    bool AddMapEntity(MapEntity mapEntity);
}