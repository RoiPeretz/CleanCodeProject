using MessageBroker.Core.Configuration;
using RabbitMQ.Client;

namespace MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow.CreateConnectionTask;

internal class CreateRabbitMqConnectionTask : ICreateRabbitMqConnectionTask
{
    private readonly ConnectionFactory _factory;

    public CreateRabbitMqConnectionTask(IMessageBrokerSettings settings)
    {
        _factory = new ConnectionFactory { HostName = settings.HostName };
    }

    public IConnection CreateConnection()
    {
        return _factory.CreateConnection();
    }
}