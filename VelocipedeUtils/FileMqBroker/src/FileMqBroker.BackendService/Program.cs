using FileMqBroker.BackendService;
using FileMqBroker.BackendService.FileContentGenerators;
using FileMqBroker.MqLibrary.Adapters.ReadAdapters;
using FileMqBroker.MqLibrary.Adapters.WriteAdapters;
using FileMqBroker.MqLibrary.DAL;
using FileMqBroker.MqLibrary.DirectoryOperations;
using FileMqBroker.MqLibrary.FileContentGenerators;
using FileMqBroker.MqLibrary.KeyCalculations;
using FileMqBroker.MqLibrary.KeyCalculations.FileNameGeneration;
using FileMqBroker.MqLibrary.KeyCalculations.RequestCollapsing;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.ResponseHandlers;
using FileMqBroker.MqLibrary.RuntimeQueues;
using FileMqBroker.MqLibrary.QueueDispatchers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Calculate path.
        var rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".."));
        var dbPath = Path.Combine(rootPath, "data", "db", "test.db");
        var reqPath = Path.Combine(rootPath, "data", "req");
        var respPath = Path.Combine(rootPath, "data", "resp");

        // App init configs.
        services.AddSingleton(_ =>
        {
            return new AppInitConfigs
            {
                // DbConnectionString = $"Data Source={dbPath};Version=3;",
                DbConnectionString = $"Server=localhost;Database=filemqbroker;User Id=postgres;Password=postgres;",
                RequestDirectoryName = reqPath,
                ResponseDirectoryName = respPath,
                OneTimeProcQueueElements = 20_000,
                ReadMqDispatcherMessageFileType = MessageFileType.Request,
                DuplicateRequestCollapseType = DuplicateRequestCollapseType.Naive
            };
        });

        // File content generation.
        services.AddSingleton<IFileContentGenerator, MessageFileResponseGen>();

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
        services.AddSingleton<ReadMqDispatcher>();
        services.AddSingleton<WriteMqDispatcher>();

        // Response handlers.
        services.AddSingleton<WriteBackResponseHandler>();

        // Backend worker service.
        services.AddHostedService<BackendServiceWorker>();
        services.AddHostedService<ReadMessagesDbWorker>();
        services.AddHostedService<WriteMessagesDbWorker>();
    })
    .Build();

await host.RunAsync();
