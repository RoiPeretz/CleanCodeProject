using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using wpfClient.Core.Configuration;
using wpfClient.Infrastructure.IocContainer;

namespace MapeeWpfClient;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;
    
    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((_, builder) =>
            {
                builder.Sources.Clear();
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddDebug();
            })
            .UseSerilog((hostBuilderContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
            })
            .ConfigureServices((hostContext, services) =>
            {
                var settings = hostContext.Configuration.GetSection(nameof(Settings)).Get<Settings>();
                services.AddWpfClientInfrastructureLibrary(settings);
                services.AddSingleton<IEntityViewModel, EntityViewModel>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start(); //Todo check if needed
        var mainWindow = _host.Services.GetService<MainWindow>();
        mainWindow?.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        _host.Dispose();
    }
}