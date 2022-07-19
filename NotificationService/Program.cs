using NotificationService;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .ConfigureLogging(builder =>
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

    }).Build();

await host.RunAsync();
