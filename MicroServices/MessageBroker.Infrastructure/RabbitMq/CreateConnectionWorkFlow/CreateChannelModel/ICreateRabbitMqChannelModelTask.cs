using RabbitMQ.Client;

namespace MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow.CreateChannelModel;

internal interface ICreateRabbitMqChannelModelTask
{
    IModel Create(IConnection connection);
}