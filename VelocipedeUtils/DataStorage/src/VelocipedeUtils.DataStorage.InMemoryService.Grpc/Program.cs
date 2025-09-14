using Serilog;
using VelocipedeUtils.DataStorage.Core.Tables;
using VelocipedeUtils.DataStorage.InMemoryService.Grpc.Services;
using VelocipedeUtils.DataStorage.Models;

var builder = WebApplication.CreateBuilder(args);

// Get main configurations.
var mainAppSettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var environmentVariableName = mainAppSettingsConfig.GetValue<string>("AppSettings:EnvironmentVariableName");
if (string.IsNullOrEmpty(environmentVariableName))
{
    throw new Exception("Environment variable name is not initialized in the appsettings.json file");
}

// Get configurations for the specific environment.
var environment = Environment.GetEnvironmentVariable(environmentVariableName)
    ?? throw new Exception($"Environment variable '{environmentVariableName}' is not initialized");
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json").Build();
var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>()
    ?? throw new Exception($"Could not initialize {nameof(AppSettings)}");
appSettings.EnvironmentVariable = environment;

// Logging.
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Services.
builder.Services.AddGrpc();
builder.Services.AddSingleton(appSettings);
builder.Services.AddSingleton<InMemoryHashTable<string, string>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<InMemoryStorageService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
