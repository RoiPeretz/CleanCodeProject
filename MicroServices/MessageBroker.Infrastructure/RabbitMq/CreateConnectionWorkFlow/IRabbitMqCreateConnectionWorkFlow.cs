using RabbitMQ.Client;

namespace MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow;

internal interface IRabbitMqCreateConnectionWorkFlow
{
    IModel Init();
}