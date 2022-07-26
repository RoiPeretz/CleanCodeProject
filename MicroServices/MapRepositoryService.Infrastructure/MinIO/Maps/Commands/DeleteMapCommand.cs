using MapRepositoryService.Core.Data.Maps.Commands;
using MapRepositoryService.Core.Models;
using Microsoft.Extensions.Logging;

namespace MapRepositoryService.Infrastructure.MinIO.Maps.Commands;

internal class DeleteMapCommand : IDeleteMapCommand
{
    private readonly ILogger<DeleteMapCommand> _logger;

    public DeleteMapCommand(ILogger<DeleteMapCommand> logger)
    {
        _logger = logger;
    }

    public ResultModel DeleteMap(string name)
    {
        _logger.LogInformation("delete Command");
        return new ResultModel(true, string.Empty);
    }
}