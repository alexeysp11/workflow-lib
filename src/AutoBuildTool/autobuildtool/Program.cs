using AutoBuildTool.Console.Managers;
using AutoBuildTool.Common.Models;
using AutoBuildTool.Console.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace AutoBuildTool;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var app = host.Services.GetRequiredService<IStartupInstance>();
        app.Start();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                ConfigureServices(services);
            });

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register application instance.
        services.AddSingleton<IStartupInstance, StartupInstance>();

        // Register modules.
        services.AddSingleton<Logger>();
        services.AddSingleton<CommandLineManager>();
        services.AddSingleton<GitManager>();
        services.AddSingleton<ProjectManager>();

        // Configuration settings.
        var appsettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var appSettings = appsettingsConfig.GetSection("AutoBuildToolSettings").Get<AutoBuildToolSettings>();
        services.AddSingleton(appSettings);
    }
}