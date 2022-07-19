using Microsoft.Extensions.DependencyInjection;
using wpfClient.Core.Configuration;
using wpfClient.Core.Parsers;
using wpfClient.Core.Services;

namespace wpfClient.Infrastructure.IocContainer;

public static class ServiceCollectionExtension
{
    public static void AddWpfClientInfrastructureLibrary(this IServiceCollection services, Settings settings)
    {
        services.AddSignalR();
        services.AddSingleton(settings);
        services.AddSingleton<INewMapEntityService, NewMapEntityService.NewMapEntityService>();
        services.AddSingleton<IMapEntityParser, MapEntityParser>();
    }
}