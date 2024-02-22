using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Models;
using WorkflowLib.Examples.ServiceInteraction.Monolith;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services => {
        // Instance of application.
        services.AddSingleton<IExampleInstance, ExampleInstance>();

        // DbContext.
        services.AddSingleton((_) => {
            return new DbContextOptionsBuilder<ServiceInteractionContext>()
                .UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicelibexample;Username=postgres;Password=postgres", 
                    b => b.MigrationsAssembly("WorkflowLib.Examples.ServiceInteraction.Core"))
                .Options;
        });
        
        // Services.
        var endpointSelectionParameter = new EndpointSelectionParameter
        {
            RetrieveFromDb = false,
            EndpointSelectionType = EndpointSelectionType.Random,
            InactiveTimeSpan = new System.TimeSpan(1, 0, 0)
        };
        services.AddSingleton<EndpointSelectionParameter>(endpointSelectionParameter);
        services.AddSingleton<EndpointPool>();
        services.AddSingleton<IEndpointLoadBalancer, RandomLoadBalancer>();
        services.AddSingleton<ConfigResolver>();
    }).Build();

var app = _host.Services.GetRequiredService<IExampleInstance>();
app.Run();
