using Microsoft.AspNetCore.Mvc;
using Serilog;
using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Background;
using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Dto;
using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Models;
using VelocipedeUtils.PixelTerminalUI.ServiceEngine.Resolvers;

var builder = WebApplication.CreateBuilder(args);

// Get configurations.
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json").Build();
var appsettings = configuration.GetSection("AppSettings").Get<AppSettings>()
    ?? throw new Exception($"Could not initialize {nameof(AppSettings)}");

// Add dependencies.
builder.Services.AddSingleton(appsettings);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services.
builder.Services.AddHostedService<SessionCheckWorker>();

// Logging.
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/pixelterminalui/go", (SessionInfoDto? sessionInfoDto, [FromServices] AppSettings appSettings) =>
{
    MenuFormResolver? menuFormResolver = null;

    // Session check.
    if (sessionInfoDto == null
        || (menuFormResolver = MemoryResolver.GetMenuFormResolver(sessionInfoDto?.SessionUid ?? "")) == null)
    {
        // Create resolver and session.
        menuFormResolver = new MenuFormResolver(appSettings);
        SessionInfo sessionInfo = menuFormResolver.InitSession();
        menuFormResolver.Start();
        MemoryResolver.SaveMenuFormResolver(sessionInfo.SessionUid, menuFormResolver, true);
        return new SessionInfoDto(sessionInfo);
    }

    // Process user input.
    string userInput = sessionInfoDto?.UserInput ?? "-n";
    menuFormResolver.ProcessUserInput(userInput);

    return new SessionInfoDto(menuFormResolver.SessionInfo);
});

app.Run();
