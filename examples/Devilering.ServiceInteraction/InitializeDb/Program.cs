using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.InitializeDb;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services => {
        // Instance of application.
        services.AddSingleton<IStartupInstance, StartupInstance>();

        // DbContext.
        services.AddSingleton((_) => {
            return new DbContextOptionsBuilder<ServiceInteractionDbContext>()
                .UseNpgsql("Server=127.0.0.1;Port=5432;Database=deliveryservicelibexample;Username=postgres;Password=postgres", 
                    b => b.MigrationsAssembly("VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL"))
                .Options;
        });
    }).Build();

var app = _host.Services.GetRequiredService<IStartupInstance>();
app.Run();
