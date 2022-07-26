using MapRepositoryService.Core.Data.Maps.Commands;
using MapRepositoryService.Core.Models;
using Microsoft.Extensions.Logging;

namespace MapRepositoryService.Infrastructure.MinIO.Maps.Commands;

internal class AddMapCommand: IAddMapCommand
{
    private readonly ILogger<AddMapCommand> _logger;

    public AddMapCommand(ILogger<AddMapCommand> logger)
    {
        _logger = logger;
    }

    public ResultModel AddMap(MapModel map)
    {
        _logger.LogInformation("add Command");
        return new ResultModel(true, string.Empty);
    }
}