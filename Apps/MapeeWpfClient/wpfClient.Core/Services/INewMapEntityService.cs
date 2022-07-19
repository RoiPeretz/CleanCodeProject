using wpfClient.Core.Models;

namespace wpfClient.Core.Services;

public interface INewMapEntityService
{
    event EventHandler<MapEntity> NewMapEntity;
    Task StartAsync();
    Task StopAsync();
}