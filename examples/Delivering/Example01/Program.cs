﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowLib.Examples.Delivering.Example01;
using WorkflowLib.Examples.Delivering.Example01.Contexts;
using WorkflowLib.Examples.Delivering.Example01.Controllers;
using WorkflowLib.Examples.Delivering.Example01.FlowchartSteps;

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services => {
        // Instance of application.
        services.AddSingleton<IStartupInstance, StartupInstance>();

        // DbContext.
        services.AddSingleton((_) => {
            string dbpath = System.IO.Path.Join("delivering.db");
            return new DbContextOptionsBuilder<DeliveringContext>().UseSqlite($"Data Source={dbpath}").Options;
        });

        // Flowchart steps.
        services.AddSingleton<MakeOrderStep>();
        services.AddSingleton<MakePaymentStep>();
        services.AddSingleton<Wh2KitchenStep>();
        services.AddSingleton<RequestStore2WhStep>();
        services.AddSingleton<Store2WhStep>();
        services.AddSingleton<ConfirmStore2WhStep>();
        services.AddSingleton<PrepareMealStep>();
        services.AddSingleton<Kitchen2WhStep>();
        services.AddSingleton<DeliverOrderStep>();
        
        // Controllers.
        services.AddSingleton<CustomerClientController>();
        services.AddSingleton<CustomerBackendController>();
    }).Build();

var app = _host.Services.GetRequiredService<IStartupInstance>();
app.Run();
