using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Shared.Models.Network;

namespace WorkflowLib.Examples.Network.Example01.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ApiOperation Get()
    {
        return new ApiOperation
        {
            IsExecuted = true,
            ResponseObject = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray()
        };
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public ApiOperation Post(ApiOperation apiOperation)
    {
        return new ApiOperation
        {
            IsExecuted = true,
            ResponseObject = "Response for the POST API method"
        };
    }
}
