using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using WorkflowLib.Examples.Delivering.ServiceInteraction.InitializeDb;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services => {
        // Instance of application.
        services.AddSingleton<IStartupInstance, StartupInstance>();

        // DbContext.
        services.AddSingleton((_) => {
            return new DbContextOptionsBuilder<ServiceInteractionDbContext>()
                .UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicelibexample;Username=postgres;Password=postgres", 
                    b => b.MigrationsAssembly("WorkflowLib.Examples.Delivering.ServiceInteraction.BL"))
                .Options;
        });
        
        // 
        services.AddSingleton<ConfigResolver>();
    }).Build();

var app = _host.Services.GetRequiredService<IStartupInstance>();
app.Run();
