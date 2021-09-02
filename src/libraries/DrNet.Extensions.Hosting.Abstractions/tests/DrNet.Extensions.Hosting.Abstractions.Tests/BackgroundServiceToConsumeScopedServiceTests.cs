using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Microsoft.Extensions.Hosting
{
    public class BackgroundServiceToConsumeScopedServiceTests
    {
        [Fact]
        public async Task Verify()
        {
            var host = CreateHostBuilder().Build();
            await host.StartAsync();
            await Task.Delay(2000);
            await host.StopAsync();
        }

        public IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) => services
                    //.AddSingleton<ILoggerFactory, NullLoggerFactory>()
                    .AddScoped<ScopedService>()
                    .AddHostedService<BackgroundServiceToConsumeScopedService<ScopedService>>()
                );
    }

    internal class ScopedService : IScopedService
    {
        private ILogger _logger;

        public ScopedService(ILogger<ScopedService> logger)
        {
            _logger = logger;
            _logger.LogInformation("ScopedService created");
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ScopedService working");

            await Task.Delay(1000);

            _logger.LogInformation("ScopedService ended");
        }
    }
}
