using Microsoft.EntityFrameworkCore;
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
using WorkflowLib.Shared.Models.Network.MicroserviceConfigurations;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.Webapi.Employee;

public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        ConfigureServices(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
    
    private static void ConfigureServices(IServiceCollection services)
    {
        // Default ASP.NET Core services.
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Register application instance.
        services.AddSingleton<IStartupInstance, StartupInstance>();
        
        // Configure DbContext.
        services.AddDbContext<ServiceInteractionDbContext>((serviceProvider, options) =>
            {
                options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicelibexample;Username=postgres;Password=postgres",
                    b => b.MigrationsAssembly("WorkflowLib.Examples.Delivering.ServiceInteraction.BL"));
            },
            ServiceLifetime.Singleton,
            ServiceLifetime.Singleton);

        // Register parameters.
        services.AddSingleton(new EndpointSelectionParameter
        {
            RetrieveFromDb = false,
            EndpointSelectionType = EndpointSelectionType.Random,
            InactiveTimeSpan = System.TimeSpan.FromHours(1)
        });
        services.AddSingleton(new StartupInitDetails
        {
            ApplicationDeploymentType = ApplicationDeploymentType.WebAPI,
            ApplicationClientType = ApplicationClientType.Employee
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
