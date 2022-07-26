using MapRepositoryService.Core.Configuration;
using MapRepositoryService.Core.Models;
using MapRepositoryService.Core.Services.Interfaces;
using MessageBroker.Core.Interfaces;

namespace MapRepositoryService.Core.Services
{
    public class MapsService : IMapsService
    {
        //private readonly IPublisher _publisher;
        //private readonly IMapsSettings _settings;

        public MapsService(IMapsSettings settings)
        {
            //_publisher = publisher;
            //_settings = settings;
        }

        public bool AddMap(MapModel map)
        {

            //var message = $"{map.name} {map.content}";
            //_publisher.Publish(_settings.MapTopic, message);

            //Todo Change to result model
            return true;
        }
    }
}
