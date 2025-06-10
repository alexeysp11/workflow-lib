using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FileMqBroker.HttpService.Controllers;
using FileMqBroker.MqLibrary.LoadTesting.Models;
using FileMqBroker.MqLibrary.Adapters.ReadAdapters;
using FileMqBroker.MqLibrary.Adapters.WriteAdapters;
using FileMqBroker.MqLibrary.DAL;
using FileMqBroker.MqLibrary.DirectoryOperations;
using FileMqBroker.MqLibrary.KeyCalculations;
using FileMqBroker.MqLibrary.KeyCalculations.FileNameGeneration;
using FileMqBroker.MqLibrary.KeyCalculations.RequestCollapsing;
using FileMqBroker.MqLibrary.LoadTesting;
using FileMqBroker.MqLibrary.LoadTesting.LoadCalculations;
using FileMqBroker.MqLibrary.LoadTesting.LoadGenerators;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.ResponseHandlers;
using FileMqBroker.MqLibrary.RuntimeQueues;
using FileMqBroker.MqLibrary.QueueDispatchers;

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

        app.Run();
    }

    /// <summary>
    /// Provides functionality for configuring services.
    /// </summary>
    private static void ConfigureServices(IServiceCollection services)
    {
        // Calculate path.
        var rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".."));
        var dbPath = Path.Combine(rootPath, "data", "db", "test.db");
        var reqPath = Path.Combine(rootPath, "data", "req");
        var respPath = Path.Combine(rootPath, "data", "resp");

        // App init configs.
        services.AddSingleton<AppInitConfigs>(_ =>
        {
            return new AppInitConfigs
            {
                // DbConnectionString = $"Data Source={dbPath};Version=3;",
                DbConnectionString = $"Server=localhost;Database=filemqbroker;User Id=postgres;Password=postgres;",
                RequestDirectoryName = reqPath,
                ResponseDirectoryName = respPath,
                OneTimeProcQueueElements = 20_000,
                ReadMqDispatcherMessageFileType = MessageFileType.Response,
                DuplicateRequestCollapseType = DuplicateRequestCollapseType.Naive
            };
        });
        services.AddSingleton<LoadConfigParams>(_ =>
        {
            return new LoadConfigParams
            {
                DeltaMax = 10000
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

        // DAL objects.
        services.AddSingleton<IMessageFileDAL, PostgresMessageFileDAL>();
        services.AddSingleton<IExceptionDAL, PostgresExceptionDAL>();
        // services.AddSingleton<IMessageFileDAL, SqliteMessageFileDAL>();
        // services.AddSingleton<IExceptionDAL, SqliteExceptionDAL>();

        // Directory operations.
        services.AddSingleton<FileHandler>();

        // Dispatchers.
        services.AddSingleton<WriteMqDispatcher>();

        // Controllers.
        services.AddSingleton<InvestmentController>();

        // Load calculations.
        services.AddSingleton<ILoadCalculation, OneTimeLoadCalculation>();

        // Load generators.
        services.AddSingleton<ILoadGenerator, LibraryLoadGenerator>();

        // Backend worker service.
        services.AddHostedService<LoadTestingWorker>();
        services.AddHostedService<WriteMqDispatcherWorker>();
    }
}
