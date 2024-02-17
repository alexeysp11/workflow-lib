using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.ExtensionServices;

public class EndpointInitializationService : IHostedService
{
    private readonly DbContextOptions<ServiceInteractionContext> _options;

    public EndpointInitializationService(DbContextOptions<ServiceInteractionContext> options)
    {
        _options = options;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Here you can perform the necessary actions to initialize the database.
        // For example, add initial data or perform migrations.

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // StopAsync method is not required to initialize the database.
        return Task.CompletedTask;
    }
}
