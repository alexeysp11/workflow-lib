﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BPInitializers;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DAL;
using WorkflowLib.Shared.ServiceDiscoveryBpm.DAL;
using WorkflowLib.Shared.ServiceDiscoveryBpm.LoadBalancers;
using WorkflowLib.Shared.ServiceDiscoveryBpm.ObjectPooling;
using WorkflowLib.Shared.ServiceDiscoveryBpm.ServiceRegistry;
using WorkflowLib.Shared.ServiceDiscoveryBpm.Routing;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Monolith;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.Shared.Models.Logging;
using WorkflowLib.Shared.Models.Network.MicroserviceConfigurations;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var app = host.Services.GetRequiredService<IStartupInstance>();
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
        services.AddSingleton<IStartupInstance, StartupInstance>();

        // Configure DbContext.
        services.AddDbContext<ServiceInteractionDbContext>((serviceProvider, options) =>
        {
            options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicelibexample;Username=postgres;Password=postgres",
                b => b.MigrationsAssembly("WorkflowLib.Examples.Delivering.ServiceInteraction.BL"));
        });

        // Register parameters.
        services.AddSingleton(new EndpointSelectionParameter
        {
            RetrieveFromDb = false,
            EndpointSelectionType = EndpointSelectionType.Random,
            InactiveTimeSpan = System.TimeSpan.FromHours(1)
        });
        services.AddSingleton(new StartupInitDetails
        {
            ApplicationDeploymentType = ApplicationDeploymentType.Monolith,
            ApplicationClientType = ApplicationClientType.CombineAll
        });

        // Endpoint selection.
        services.AddSingleton<TransitionPool>();
        services.AddSingleton<EndpointPool>();
        services.AddSingleton<IEsbLoadBalancer, RandomLoadBalancer>();
    
        // Business process initializers.
        services.AddSingleton<BPTransitionInitializer>();
        services.AddSingleton<ProcPipeInitializer>();

        // Service mesh.
        services.AddSingleton<IEsbServiceRegistry, EsbServiceRegistry>();
        services.AddSingleton<EsbRoutingConfigs>();
        services.AddSingleton<EsbControlPlane>();

        // DAL.
        services.AddSingleton<ILoggingDAL, LoggingDAL>();
        services.AddSingleton<DeliveryOrderDAL>();
        services.AddSingleton<IEndpointDAL, EndpointDAL>();
        services.AddSingleton<IBusinessProcessDAL, BusinessProcessDAL>();

        // Services.
        services.AddSingleton<CustomerBLController>();
        services.AddSingleton<WarehouseBLController>();
        services.AddSingleton<CourierBLController>();
        services.AddSingleton<KitchenBLController>();
        services.AddSingleton<FileService>();
    }
}
