using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FileMqBroker.MqLibrary.Adapters.ReadAdapters;
using FileMqBroker.MqLibrary.Adapters.WriteAdapters;
using FileMqBroker.MqLibrary.KeyCalculations;
using FileMqBroker.MqLibrary.KeyCalculations.FileNameGeneration;
using FileMqBroker.MqLibrary.KeyCalculations.RequestCollapsing;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.ResponseHandlers;
using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.HttpService;

/// <summary>
/// Initializes the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method in the application.
    /// </summary>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services);
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    /// <summary>
    /// Provides functionality for configuring services.
    /// </summary>
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // App init configs.
        services.AddSingleton<AppInitConfigs>(_ =>
        {
            return new AppInitConfigs
            {
                DbConnectionString = "",
                RequestDirectoryName = "",
                ResponseDirectoryName = "",
                OneTimeProcQueueElements = 20_000,
                DuplicateRequestCollapseType = DuplicateRequestCollapseType.Naive
            };
        });

        // Key calculations.
        services.AddSingleton<KeyCalculationMD5>();
        services.AddSingleton<KeyCalculationSHA256>();
        services.AddSingleton<IFileNameGeneration, FileNameGenerationMD5>();
        services.AddSingleton<IRequestCollapser, RequestCollapserSHA256>();

        // Queues.
        services.AddSingleton<ReadMessageFileQueue>();
        services.AddSingleton<WriteMessageFileQueue>();

        // Queue adapters.
        services.AddSingleton<IReadAdapter, FileMqReadAdapter>();
        services.AddSingleton<IWriteAdapter, FileMqWriteAdapter>();

        // Backend worker service.
        services.AddHostedService<HttpResponseWorker>();
    }
}