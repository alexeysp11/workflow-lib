using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.DbContexts;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Domain.DatasetGenerators;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Domain.Filtering;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Models.Configurations;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Get configurations.
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json").Build();
var appsettings = configuration.GetSection("AppSettings").Get<AppSettings>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(appsettings);
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<DatasetGenerator>();
builder.Services.AddTransient<ICommonDataFilter, CommonDataFilter>();
builder.Services.AddDbContext<EmployeesMvcDbContext>(
        options => options.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=employeesmvc_test;Pooling=true;Integrated Security=true;"));

var app = builder.Build();

// Initialize datasets.
var datasetGenerator = app.Services.GetService<DatasetGenerator>();
datasetGenerator.Initialize();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
