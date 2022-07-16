using RabbitMQ.Client;

namespace MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow.CreateConnectionTask;

internal interface ICreateRabbitMqConnectionTask
{
    IConnection CreateConnection();
}