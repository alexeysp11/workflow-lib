using Microsoft.AspNetCore.Mvc;
using PixelTerminalUI.ServiceEngine.Dto;
using PixelTerminalUI.ServiceEngine.Models;
using PixelTerminalUI.ServiceEngine.Resolvers;

var builder = WebApplication.CreateBuilder(args);

// Get configurations.
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json").Build();
var appsettings = configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();

// Add dependencies.
builder.Services.AddSingleton(appsettings);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    MenuFormResolver menuFormResolver = null;

    // Session check.
    if (sessionInfoDto == null
        || (menuFormResolver = MemoryResolver.GetMenuFormResolver(sessionInfoDto?.SessionUid)) == null)
    {
        // Create resolver and session.
        menuFormResolver = new MenuFormResolver(appSettings);
        SessionInfo sessionInfo = menuFormResolver.InitSession();
        menuFormResolver.Start();
        MemoryResolver.SaveMenuFormResolver(sessionInfo.SessionUid, menuFormResolver);
        return new SessionInfoDto(sessionInfo);
    }

    // Authentication check.

    // Process user input.
    string userInput = sessionInfoDto?.UserInput ?? "-n";
    menuFormResolver.ProcessUserInput(userInput);

    return new SessionInfoDto(menuFormResolver.SessionInfo);
});

app.Run();
