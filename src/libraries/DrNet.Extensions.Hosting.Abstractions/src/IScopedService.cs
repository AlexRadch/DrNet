// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// Consumed scoped service should implement this interface. <see cref="BackgroundServiceToConsumeScopedService{TScopedService}"/>
    /// </summary>
    public interface IScopedService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}
