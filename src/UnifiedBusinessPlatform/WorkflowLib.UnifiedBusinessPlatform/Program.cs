using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using WorkflowLib.UnifiedBusinessPlatform.Core.DbContexts;
using WorkflowLib.UnifiedBusinessPlatform.Core.Domain.DatasetGenerators;
using WorkflowLib.UnifiedBusinessPlatform.Core.Domain.Filtering;
using WorkflowLib.UnifiedBusinessPlatform.Core.Models.Configurations;
using WorkflowLib.UnifiedBusinessPlatform.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Get configurations.
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.{environment}.json").Build();
var appsettings = configuration.GetSection("AppSettings").Get<AppSettings>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.LoginPath = "/Auth/SignIn";
    });

// Add dependencies.
builder.Services.AddSingleton(appsettings);
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<DatasetGenerator>();
builder.Services.AddTransient<ICommonDataFilter, CommonDataFilter>();
builder.Services.AddDbContext<UbpDbContext>(options => options.UseNpgsql(appsettings.ConnectionString));

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

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
