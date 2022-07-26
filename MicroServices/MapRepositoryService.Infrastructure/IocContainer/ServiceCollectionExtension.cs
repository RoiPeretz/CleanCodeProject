using MapRepositoryService.Core.Configuration;
using MapRepositoryService.Core.Services;
using MapRepositoryService.Core.Services.Interfaces;
using MessageBroker.Core.Configuration;
using MessageBroker.Infrastructure.IocContainer;
using Microsoft.Extensions.DependencyInjection;

namespace MapRepositoryService.Infrastructure.IocContainer
{
    public static class ServiceCollectionExtension
    {
        public static void AddMapsInfrastructureLibrary(this IServiceCollection services, MapsSettings mapsSettings)
        {
            services.AddSingleton<IMapsSettings>(mapsSettings);
            services.AddTransient<IMapsService, MapsService>();

            services.AddMessageBrokerInfrastructureLibrary(new MessageBrokerSettings
            {
                HostName = mapsSettings.HostName
            });
        }
    }
}
