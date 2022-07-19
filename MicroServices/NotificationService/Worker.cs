using MessageBroker.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Commands.NewMapEntity;
using NotificationService.Configuration;
using NotificationService.Hubs;

namespace NotificationService
{
    public class Worker : BackgroundService
    {
        private readonly INewMapEntityCommandHandler _newMapEntityCommandHandler;
        private readonly ISubscriber _subscriber;
        private readonly INotificationServiceSettings _settings;
        private readonly ILogger<Worker> _logger;

        public Worker(
            INewMapEntityCommandHandler newMapEntityCommandHandler,
            ISubscriber subscriber,
            INotificationServiceSettings notificationServiceSettings,
            ILogger<Worker> logger)
        {
            _newMapEntityCommandHandler = newMapEntityCommandHandler;
            _subscriber = subscriber;
            _settings = notificationServiceSettings;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var topic = _settings.MapEntityTopic;

            _subscriber.Subscribe(topic, _newMapEntityCommandHandler.OnNewMapEntity);
            return Task.CompletedTask;
        }
    }
}