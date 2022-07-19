using System.Collections.ObjectModel;
using wpfClient.Core.Models;

namespace MapeeWpfClient;

public interface IEntityViewModel
{
    ObservableCollection<MapEntity> MapEntities { get; }
}