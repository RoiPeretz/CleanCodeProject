using MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow.CreateChannelModel;
using MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow.CreateConnectionTask;
using RabbitMQ.Client;

namespace MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow;

internal class RabbitMqCreateConnectionWorkFlow : IRabbitMqCreateConnectionWorkFlow
{
    private readonly ICreateRabbitMqChannelModelTask _createChannelModelTask;
    private readonly ICreateRabbitMqConnectionTask _createConnectionTask;

    public RabbitMqCreateConnectionWorkFlow(ICreateRabbitMqConnectionTask createConnectionTask,
        ICreateRabbitMqChannelModelTask createChannelModelTask)
    {
        _createConnectionTask = createConnectionTask;
        _createChannelModelTask = createChannelModelTask;
    }

    public IModel Init()
    {
        var connection = _createConnectionTask.CreateConnection();
        var model = _createChannelModelTask.Create(connection);
        return model;
    }
}