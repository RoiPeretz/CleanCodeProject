using MapRepositoryService.Core.Models;

namespace MapRepositoryService.Core.Data.Maps.Queries;

public interface IGetMapsQuery
{
    ResultModel<IEnumerable<string>> GetMaps();
}