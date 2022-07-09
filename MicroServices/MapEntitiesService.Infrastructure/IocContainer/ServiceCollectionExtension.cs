using MapEntitiesService.Core.Services;
using MapEntitiesService.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MapEntitiesService.Infrastructure.IocContainer;

public static class ServiceCollectionExtension
{
    public static void AddMapEntitiesInfrastructureLibrary(this IServiceCollection services)
    {
        services.AddTransient<IMapEntityService, MapEntityService>();
    }
}