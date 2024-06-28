using WorkflowLib.Examples.PublicTransportDevices.Models;
using WorkflowLib.Examples.PublicTransportDevices.DbConnections;
using WorkflowLib.Examples.PublicTransportDevices.Models.Domain; 
using WorkflowLib.Examples.PublicTransportDevices.Models.MessageQueues; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICommonDbConnection>(x => 
    ActivatorUtilities.CreateInstance<PgDbConnection>(x, builder.Configuration.GetSection("AppSettings")["PostgresConnectionString"]));
builder.Services.AddTransient<DeviceInfoDb>(); 
builder.Services.AddSingleton(new RabbitMQConsumer(builder.Services.BuildServiceProvider().GetRequiredService<DeviceInfoDb>())); 

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
