using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.ECommerce.FoodDelivery.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Get configurations.
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json").Build();
var appsettings = configuration.GetSection("AppSettings").Get<AppSettings>()
    ?? throw new Exception($"Cannot start the application: '{nameof(AppSettings)}' section is not specified in the config file");
if (string.IsNullOrEmpty(appsettings.ConnectionString))
{
    throw new Exception($"Cannot start the application: connection string is not initialized");
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dependencies.
builder.Services.AddSingleton(appsettings);
builder.Services.AddDbContext<FoodDeliveryDbContext>(options => options.UseNpgsql(appsettings.ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
