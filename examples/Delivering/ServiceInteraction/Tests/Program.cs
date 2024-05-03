using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DAL;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.LoadBalancers;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ObjectPooling;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ServiceRegistry;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Tests;
using WorkflowLib.Models.Network.MicroserviceConfigurations;

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
        services.AddSingleton((_) => {
            return new DbContextOptionsBuilder<ServiceInteractionDbContext>()
                .UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicelibexample;Username=postgres;Password=postgres", 
                    b => b.MigrationsAssembly("WorkflowLib.Examples.Delivering.ServiceInteraction.BL"))
                .Options;
        });
        
        // Register services.
        services.AddSingleton<EndpointSelectionParameter>(new EndpointSelectionParameter
        {
            RetrieveFromDb = false,
            EndpointSelectionType = EndpointSelectionType.Random,
            InactiveTimeSpan = TimeSpan.FromHours(1)
        });

        services.AddSingleton<EndpointPool>();
        services.AddSingleton<IEsbLoadBalancer, RandomLoadBalancer>();
        services.AddSingleton<IEsbServiceRegistry, EsbServiceRegistry>();

        // DAL.
        services.AddSingleton<IEndpointDAL, EndpointDAL>();
        services.AddSingleton<IBusinessProcessDAL, BusinessProcessDAL>();
    }
}
