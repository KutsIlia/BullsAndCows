using Serilog;
using Serilog.Events;
namespace PCGame
{
    internal class LogConfig
    {
        private static readonly ILogger Logger;

        static LogConfig()
        {
            Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static ILogger GetLogger()
        {
            return Logger;
        }
    }
}
