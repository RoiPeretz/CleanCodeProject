using MessageBroker.Core.Configuration;
using MessageBroker.Infrastructure.IocContainer;
using Microsoft.AspNetCore.Http.Connections;
using NotificationService;
using NotificationService.Commands.NewMapEntity;
using NotificationService.Configuration;
using NotificationService.Hubs;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection(nameof(NotificationServiceSettings)).Get<NotificationServiceSettings>();
builder.Services.AddSingleton<INotificationServiceSettings>(settings);

builder.Services.AddSignalR();
builder.Services.AddSingleton<INewMapEntityCommandHandler, NewMapEntityCommandHandler>();
builder.Services.AddMessageBrokerInfrastructureLibrary(new MessageBrokerSettings
{
    HostName = settings.HostName
});

#region Logger
builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
});
#endregion

builder.Services.AddHostedService<Worker>();

var app = builder.Build();
app.MapHub<MapEntityNotificationHub>("/ws", options =>
{
    options.Transports = HttpTransportType.WebSockets;
});

app.Run();