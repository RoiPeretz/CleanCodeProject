using RabbitMQ.Client;

namespace MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow.CreateChannelModel;

internal class CreateRabbitMqChannelModelTask : ICreateRabbitMqChannelModelTask
{
    public IModel Create(IConnection connection)
    {
        return connection.CreateModel();
    }
}