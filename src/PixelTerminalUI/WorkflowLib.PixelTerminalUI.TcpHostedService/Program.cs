using TcpHostedService;
using WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<TcpServerService>();

// Get configurations.
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json").Build();
var appsettings = configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();

// Add dependencies.
builder.Services.AddSingleton(appsettings);
//builder.Services.AddDbContext<EmployeesMvcDbContext>(options => options.UseNpgsql(appsettings.ConnectionString));

var host = builder.Build();
host.Run();
