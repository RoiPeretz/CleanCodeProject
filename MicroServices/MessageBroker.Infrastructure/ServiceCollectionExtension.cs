using MessageBroker.Core;
using MessageBroker.Infrastructure.RabbitMq;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Infrastructure;

public static class ServiceCollectionExtension
{
    public static void AddMessageBrokerInfrastructureLibrary(this IServiceCollection services)
    {
        services.AddSingleton<IPublisher, RabbitMQPublisher>();
    }
}