using Serilog;
using WorkflowLib.DataStorage.Core.Tables;
using WorkflowLib.DataStorage.InMemoryService.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Get configurations.
var environmentVariableName = "ASPNETCORE_ENVIRONMENT";
var environment = Environment.GetEnvironmentVariable(environmentVariableName)
    ?? throw new Exception($"Environment variable '{environmentVariableName}' is not initialized");
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json").Build();
// var appsettings = configuration.GetSection("AppSettings").Get<AppSettings>()
//     ?? throw new Exception($"Could not initialize {nameof(AppSettings)}");

// Logging.
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Services.
builder.Services.AddGrpc();
builder.Services.AddSingleton<InMemoryHashTable<string, string>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<InMemoryStorageService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
