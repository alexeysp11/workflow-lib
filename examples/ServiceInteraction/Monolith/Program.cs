﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowLib.Examples.ServiceInteraction.BL;
using WorkflowLib.Examples.ServiceInteraction.Core;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Models;
using WorkflowLib.Examples.ServiceInteraction.Monolith;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var app = host.Services.GetRequiredService<IExampleInstance>();
        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                ConfigureServices(services);
            });

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register application instance.
        services.AddSingleton<IExampleInstance, ExampleInstance>();

        // Configure DbContext.
        services.AddDbContext<ServiceInteractionContext>((serviceProvider, options) =>
        {
            options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicelibexample;Username=postgres;Password=postgres",
                b => b.MigrationsAssembly("WorkflowLib.Examples.ServiceInteraction.Core"));
        });

        // Register services.
        services.AddSingleton<EndpointSelectionParameter>(new EndpointSelectionParameter
        {
            RetrieveFromDb = false,
            EndpointSelectionType = EndpointSelectionType.Random,
            InactiveTimeSpan = System.TimeSpan.FromHours(1)
        });

        // Endpoint selection.
        services.AddSingleton<EndpointPool>();
        services.AddSingleton<IEndpointLoadBalancer, RandomLoadBalancer>();
        services.AddSingleton<LoggingDAL>();

        // Services.
        services.AddSingleton<ServiceA>();
        services.AddSingleton<ServiceB>();
        services.AddSingleton<ServiceC>();
        services.AddSingleton<ServiceD>();
        services.AddSingleton<ServiceE>();
    }
}
