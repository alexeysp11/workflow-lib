using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Cims.WorkflowLib.Example01;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Example01.FlowchartSteps;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services => {
        services.AddSingleton<IExampleInstance, ExampleInstance>();
        // services.AddDbContext<DeliveringContext>(
        //     optionsAction: (optionsBuilder) => optionsBuilder.UseInMemoryDatabase(databaseName: "mydatabase"),
        //     contextLifetime: ServiceLifetime.Singleton,
        //     optionsLifetime: ServiceLifetime.Singleton);
        services.AddSingleton((_) => {
            return new DbContextOptionsBuilder<DeliveringContext>().UseInMemoryDatabase(databaseName: "mydatabase").Options;
        });
        services.AddSingleton<MakeOrderStep>();
        services.AddSingleton<MakePaymentStep>();
        services.AddSingleton<FinishWh2KitchenStep>();
        services.AddSingleton<RequestStore2WhStep>();
        services.AddSingleton<FinishStore2WhStep>();
        services.AddSingleton<ConfirmStore2WhStep>();
        services.AddSingleton<PrepareMealStep>();
        services.AddSingleton<Kitchen2WhStep>();
        services.AddSingleton<ScanQrOnOrderStep>();
        services.AddSingleton<ScanBackpackStep>();
        services.AddSingleton<DeliverOrderStep>();
    }).Build();

var app = _host.Services.GetRequiredService<IExampleInstance>();
app.Run();
