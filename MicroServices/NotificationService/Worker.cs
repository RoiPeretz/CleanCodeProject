using MessageBroker.Core.Interfaces;
using NotificationService.Commands.NewMapEntity;
using NotificationService.Configuration;

namespace NotificationService
{
    public class Worker : BackgroundService
    {
        private readonly INewMapEntityCommandHandler _newMapEntityCommandHandler;
        private readonly ISubscriber _subscriber;
        private readonly INotificationServiceSettings _settings;

        public Worker(
            INewMapEntityCommandHandler newMapEntityCommandHandler,
            ISubscriber subscriber,
            INotificationServiceSettings notificationServiceSettings)
        {
            _newMapEntityCommandHandler = newMapEntityCommandHandler;
            _subscriber = subscriber;
            _settings = notificationServiceSettings;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber.Subscribe(_settings.MapEntityTopic, _newMapEntityCommandHandler.OnNewMapEntity);
            return Task.CompletedTask;
        }
    }
}