// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.Hosting
{
    public class BackgroundWorker<T> : BackgroundService where T : IScopedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<BackgroundWorker<T>>? _logger;

        public BackgroundWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public BackgroundWorker(IServiceScopeFactory scopeFactory, ILogger<BackgroundWorker<T>> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger?.LogTrace($"BackgroundWorker<{nameof(T)}> running.");

            using (var scope = _scopeFactory.CreateScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<T>();

                _logger?.LogTrace($"BackgroundWorker<{nameof(T)}> is working.");

                await scopedService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger?.LogInformation($"BackgroundWorker<{nameof(T)}> is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
