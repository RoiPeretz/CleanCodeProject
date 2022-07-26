using MapRepositoryService.Core.Models;

namespace MapRepositoryService.Core.Data.Maps.Commands;

public interface IDeleteMapCommand
{
    ResultModel DeleteMap(string name);
}