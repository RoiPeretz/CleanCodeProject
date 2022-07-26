using MapRepositoryService.Core.Data.Maps.Commands;
using MapRepositoryService.Core.Data.Maps.Queries;
using MapRepositoryService.Core.Models;
using MapRepositoryService.Core.Services.Interfaces;
using MapRepositoryService.Core.Validations.Interfaces;

namespace MapRepositoryService.Core.Services;

public class MapsService : IMapsService
{
    private readonly IAddMapCommand _addMapCommand;
    private readonly IDeleteMapCommand _deleteMapCommand;
    private readonly IGetMapsQuery _getMapsQuery;
    private readonly IGetMapQuery _getMapQuery;
    private readonly IUploadMapValidation _uploadMapValidation;

    public MapsService(IAddMapCommand addMapCommand,
        IDeleteMapCommand deleteMapCommand,
        IGetMapsQuery getMapsQuery,
        IGetMapQuery getMapQuery,
        IUploadMapValidation uploadMapValidation)
    {
        _addMapCommand = addMapCommand;
        _deleteMapCommand = deleteMapCommand;
        _getMapsQuery = getMapsQuery;
        _getMapQuery = getMapQuery;
        _uploadMapValidation = uploadMapValidation;
    }

    public ResultModel AddMap(MapModel map)
    {
        var mapValidationResult = _uploadMapValidation.Validate(map);
        if (mapValidationResult.Success)
        {
            return _addMapCommand.AddMap(map);
        }

        return mapValidationResult;
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