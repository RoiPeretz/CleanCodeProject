using System.Text;
using MessageBroker.Core.Interfaces;
using MessageBroker.Infrastructure.RabbitMq.CreateConnectionWorkFlow;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker.Infrastructure.RabbitMq;

internal class RabbitMqSubscriber : IDisposable, ISubscriber
{
    private readonly IModel _channel;
    private readonly ILogger _logger;

    public RabbitMqSubscriber(IRabbitMqCreateConnectionWorkFlow rabbitMqCreateConnectionWorkFlow,
        ILogger<RabbitMqSubscriber> logger)
    {
        _channel = rabbitMqCreateConnectionWorkFlow.Init();
        _logger = logger;
    }

    //TODO Unsubscribe

    public void Dispose()
    {
        _channel.Dispose();
    }

    public void Subscribe(string topic, Action<string> onMessage)
    {
        try
        {
            _channel.ExchangeDeclare(topic, ExchangeType.Fanout);

            _channel.QueueDeclare(topic,
                false,
                false,
                false,
                null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (_, ea) =>
            {
                Console.WriteLine(topic);
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                onMessage.Invoke(message);
            };

            _channel.BasicConsume(topic,
                true,
                consumer);
        }
        catch (Exception ex)
        {
            //TODO set result when we add return type
            _logger.LogError(ex.Message);
        }
    }
}