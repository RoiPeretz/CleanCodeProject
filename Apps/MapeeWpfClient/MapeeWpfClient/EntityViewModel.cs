using System;
using System.Collections.ObjectModel;
using wpfClient.Core.Models;
using wpfClient.Core.Services;

namespace MapeeWpfClient;

internal class EntityViewModel: IDisposable, IEntityViewModel
{
    public ObservableCollection<MapEntity> MapEntities { get; }
    private readonly INewMapEntityService _newMapEntityService;

    public EntityViewModel(INewMapEntityService newMapEntityService)
    {
        _newMapEntityService = newMapEntityService;
        MapEntities = new ObservableCollection<MapEntity>();

        _newMapEntityService.NewMapEntity += OnNewMapEntity;
        try
        {
            _newMapEntityService.StartAsync();
        }
        catch (Exception ex)
        {

        }

    }

    private void OnNewMapEntity(object? sender, MapEntity e)
    {
        MapEntities.Add(e);
    }

    public void Dispose()
    {
        _newMapEntityService.NewMapEntity -= OnNewMapEntity;
        _newMapEntityService.StopAsync();
    }
}