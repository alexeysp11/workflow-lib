using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BPInitializers;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Controllers;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DAL;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.DAL;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.LoadBalancers;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.ObjectPooling;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.ServiceRegistry;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.Routing;
using VelocipedeUtils.Shared.Models.Network.MicroserviceConfigurations;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.Webapi.Employee;

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
                    b => b.MigrationsAssembly("VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL"));
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
