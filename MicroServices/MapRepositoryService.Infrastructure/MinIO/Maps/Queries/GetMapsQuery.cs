using MapRepositoryService.Core.Data.Maps.Queries;
using MapRepositoryService.Core.Models;
using Microsoft.Extensions.Logging;

namespace MapRepositoryService.Infrastructure.MinIO.Maps.Queries;

internal class GetMapsQuery: IGetMapsQuery
{
    private readonly ILogger<GetMapsQuery> _logger;

    public GetMapsQuery(ILogger<GetMapsQuery> logger)
    {
        _logger = logger;
    }

    public ResultModel<IEnumerable<string>> GetMaps()
    {
        var names = new List<string>
        {
            "Map1",
            "Map2",
            "Map3"
        };

        _logger.LogInformation("Get maps");
        return new ResultModel<IEnumerable<string>>(true, string.Empty, names);
    }
}