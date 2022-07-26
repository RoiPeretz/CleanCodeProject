using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using wpfClient.Core.Configuration;
using wpfClient.Core.Logging;
using wpfClient.Core.Models;
using wpfClient.Core.Parsers;
using wpfClient.Core.Services;

namespace wpfClient.Infrastructure.NewMapEntityService;

internal class NewMapEntityService : INewMapEntityService, IDisposable
{
    public event EventHandler<MapEntity> NewMapEntity = delegate { };
    private readonly HubConnection _connection;
    private readonly ILogger<INewMapEntityService> _logger;

    public NewMapEntityService(ILogger<INewMapEntityService> logger, IMapEntityParser mapEntityParser, Settings settings)
    {
        _logger = logger;
        _connection = new HubConnectionBuilder()
            .WithUrl(settings.NewMapEntityUrl)
            .WithAutomaticReconnect()
             .ConfigureLogging(logging =>
             {
                 logging.AddProvider(_logger.AsLoggerProvider());
             })
            .Build();

        _connection.On<string, string>(settings.NewMapEntityMethod, (user, message) =>
        {
            _logger.LogInformation($"new entity received - {message}");
            var entity = mapEntityParser.Parse(message);

            if (entity == null) return;
            NewMapEntity.Invoke(this, entity);
        });
    }

    public Task StartAsync()
    {
        _logger.LogInformation("NewMapEntityService started");
        return _connection.StartAsync();
    }

    public Task StopAsync()
    {
        _logger.LogInformation("NewMapEntityService stopped");
        return _connection.StopAsync();
    }

    public void Dispose()
    {
        StopAsync();
        _connection.DisposeAsync();
    }
}