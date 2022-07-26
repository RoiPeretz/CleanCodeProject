using MapRepositoryService.Core.Data.Maps.Commands;
using MapRepositoryService.Core.Data.Maps.Queries;
using MapRepositoryService.Core.Models;
using MapRepositoryService.Core.Services.Interfaces;

namespace MapRepositoryService.Core.Services;

public class MapsService : IMapsService
{
    private readonly IAddMapCommand _addMapCommand;
    private readonly IDeleteMapCommand _deleteMapCommand;
    private readonly IGetMapsQuery _getMapsQuery;
    private readonly IGetMapQuery _getMapQuery;

    public MapsService(IAddMapCommand addMapCommand,
        IDeleteMapCommand deleteMapCommand,
        IGetMapsQuery getMapsQuery,
        IGetMapQuery getMapQuery)
    {
        _addMapCommand = addMapCommand;
        _deleteMapCommand = deleteMapCommand;
        _getMapsQuery = getMapsQuery;
        _getMapQuery = getMapQuery;
    }

    public ResultModel AddMap(MapModel map)
    {
        return _addMapCommand.AddMap(map);
    }

    public ResultModel<string> GetMap(string mapName)
    {
        return _getMapQuery.GetMap(mapName);
    }

    public ResultModel<IEnumerable<string>> GetMaps()
    {
        return _getMapsQuery.GetMaps();
    }

    public ResultModel DeleteMap(string name)
    {
        return _deleteMapCommand.DeleteMap(name);
    }
}