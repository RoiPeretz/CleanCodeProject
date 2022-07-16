using MapEntitiesService.Core.Configuration;
using MapEntitiesService.Core.Services;
using MapEntitiesService.Core.Services.Interfaces;
using MessageBroker.Core.Configuration;
using MessageBroker.Infrastructure.IocContainer;
using Microsoft.Extensions.DependencyInjection;

namespace MapEntitiesService.Infrastructure.IocContainer;

public static class ServiceCollectionExtension
{
    public static void AddMapEntitiesInfrastructureLibrary(this IServiceCollection services, MapEntitiesSettings mapEntitiesSettings)
    {
        services.AddSingleton<IMapEntitiesSettings>(mapEntitiesSettings);
        services.AddTransient<IMapEntityService, MapEntityService>();

        services.AddMessageBrokerInfrastructureLibrary(new MessageBrokerSettings
        {
            HostName = mapEntitiesSettings.HostName
        });
    }
}