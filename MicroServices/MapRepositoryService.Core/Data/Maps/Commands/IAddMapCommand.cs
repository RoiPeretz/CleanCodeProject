using MapRepositoryService.Core.Models;

namespace MapRepositoryService.Core.Data.Maps.Commands;

public interface IAddMapCommand
{
    ResultModel AddMap(MapModel map);
}