using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
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
        
        // 
        services.AddSingleton<ConfigResolver>();
    }).Build();

var app = _host.Services.GetRequiredService<IExampleInstance>();
app.Run();
