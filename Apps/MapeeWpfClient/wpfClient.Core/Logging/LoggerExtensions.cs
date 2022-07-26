using Microsoft.Extensions.Logging;

namespace wpfClient.Core.Logging;


public static class LoggerExtensions
{
    public static ILoggerProvider AsLoggerProvider(this ILogger logger)
    {
        return new ExistingLoggerProvider(logger);
    }

    private class ExistingLoggerProvider : ILoggerProvider
    {
        private readonly ILogger _logger;

        public ExistingLoggerProvider(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _logger;
        }
        public void Dispose()
        {
            return;
        }

    }
}