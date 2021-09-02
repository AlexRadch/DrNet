// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Background service that consume scoped service.
    /// 
    /// The services should be registered in <see cref="IHostBuilder.ConfigureServices(System.Action{HostBuilderContext, IServiceCollection})"/> (Program.cs)
    /// The scoped service should be registered with the <see cref="ServiceCollectionServiceExtensions.AddScoped{TService, TImplementation}(IServiceCollection)"/> extension method.
    /// The hosted service should be registered with the <see cref="ServiceCollectionHostedServiceExtensions.AddHostedService{THostedService}(IServiceCollection)"/> extension method.
    /// <code>
    /// services.AddScoped<IScopedService, ScopedService>();
    /// services.AddHostedService<BackgroundServiceToConsumeScopedService<IScopedService>>();
    /// </code>
    /// </summary>
    /// 
    /// <seealso href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio#consuming-a-scoped-service-in-a-background-task">
    /// Consuming a scoped service in a background task
    /// </seealso>
    /// 
    /// <seealso href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio#backgroundservice-base-class">
    /// BackgroundService base class
    /// </seealso>
    /// 
    /// <typeparam name="TScopedService">
    /// The scoped service that should implement <see cref="IScopedService"/> interface.
    /// The scoped service should be registered in <see cref="IHostBuilder.ConfigureServices(System.Action{HostBuilderContext, IServiceCollection})"/> (Program.cs)
    /// with the <see cref="ServiceCollectionServiceExtensions.AddScoped{TService, TImplementation}(IServiceCollection)"/> extension method.
    /// </typeparam>
    public class BackgroundServiceToConsumeScopedService<TScopedService> : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<BackgroundServiceToConsumeScopedService<TScopedService>>? _logger;

        public BackgroundServiceToConsumeScopedService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public BackgroundServiceToConsumeScopedService(IServiceScopeFactory scopeFactory, ILogger<BackgroundServiceToConsumeScopedService<TScopedService>> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        /// <summary>
        /// Creates scope <see cref="IServiceScope"/> from scope factory <see cref="IServiceScopeFactory.CreateScope"/>.
        /// Get scoped service <see cref="TScopedService"/> from <see cref="ServiceProviderServiceExtensions.GetRequiredService{T}(IServiceProvider)"/>.
        /// Cast scoped service <see cref="TScopedService"/> to <see cref="IScopedService"/> interface and run it by calling <see cref="IScopedService.DoWork(CancellationToken)"/> method.
        /// </summary>
        /// 
        /// <param name="stoppingToken"></param>
        /// 
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger?.LogTrace($"BackgroundWorker<{nameof(TScopedService)}> running.");

            using (var scope = _scopeFactory.CreateScope())
            {
                var scopedService = (IScopedService)scope.ServiceProvider.GetRequiredService<TScopedService>();

                _logger?.LogTrace($"BackgroundWorker<{nameof(TScopedService)}> is working.");
                await scopedService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger?.LogInformation($"BackgroundWorker<{nameof(TScopedService)}> is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
