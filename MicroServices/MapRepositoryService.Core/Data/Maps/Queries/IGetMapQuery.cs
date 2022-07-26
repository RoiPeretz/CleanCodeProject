using MapRepositoryService.Core.Models;

namespace MapRepositoryService.Core.Data.Maps.Queries;

public interface IGetMapQuery
{
    ResultModel<string> GetMap(string mapName);
}