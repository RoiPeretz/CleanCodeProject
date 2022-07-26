using MapRepositoryService.Core.Models;
namespace MapRepositoryService.Core.Services.Interfaces;

public interface IMapsService
{
    ResultModel AddMap(MapModel map);
    ResultModel<string> GetMap(string mapName);
    ResultModel<IEnumerable<string>> GetMaps();
    ResultModel DeleteMap(string name);
}