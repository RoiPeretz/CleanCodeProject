using MapRepositoryService.Core.Data.Maps.Queries;

namespace MapRepositoryService.Infrastructure.MinIO.Maps.Queries;

internal class MapExistsQuery : IMapExistsQuery
{
    public bool Exists(string name)
    {
        //Todo - implement
        return true;
    }
}