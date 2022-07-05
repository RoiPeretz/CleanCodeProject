using MessageBroker.Core;
using Microsoft.Extensions.Logging;

namespace MessageBroker.Infrastructure.RabbitMq;

internal class RabbitMQPublisher : IPublisher
{
    private readonly ILogger<RabbitMQPublisher> _logger;    
    
    public RabbitMQPublisher(ILogger<RabbitMQPublisher> logger)
    {
        _logger = logger;
    }
    
    public void Publish(string topic, string message)
    {
        _logger.LogInformation("Published {topic} - {message}", topic, message);
    }
}