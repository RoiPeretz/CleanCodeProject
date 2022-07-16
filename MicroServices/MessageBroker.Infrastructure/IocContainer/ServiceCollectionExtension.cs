using MessageBroker.Core.Configuration;
using MessageBroker.Core.Interfaces;
using MessageBroker.Infrastructure.RabbitMq;
using MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow;
using MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow.CreateChannelModel;
using MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow.CreateConnectionTask;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Infrastructure.IocContainer;

public static class ServiceCollectionExtension
{
    public static void AddMessageBrokerInfrastructureLibrary(this IServiceCollection services,
        MessageBrokerSettings messageBrokerSettings)
    {
        services.AddSingleton<IMessageBrokerSettings>(messageBrokerSettings);

        services.AddTransient<ICreateRabbitMqConnectionTask, CreateRabbitMqConnectionTask>();
        services.AddTransient<ICreateRabbitMqChannelModelTask, CreateRabbitMqChannelModelTask>();
        services.AddTransient<IRabbitMqCreateConnectionWorkFlow, RabbitMqCreateConnectionWorkFlow>(); 

        services.AddSingleton<IPublisher, RabbitMqPublisher>();
        services.AddSingleton<ISubscriber, RabbitMqSubscriber>();
    }
}