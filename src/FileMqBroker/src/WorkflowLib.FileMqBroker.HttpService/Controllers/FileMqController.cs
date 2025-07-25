using Microsoft.AspNetCore.Mvc;

namespace WorkflowLib.FileMqBroker.HttpService.Controllers;

[ApiController]
[Route("[controller]")]
public class FileMqController : ControllerBase
{
    private readonly ILogger<FileMqController> _logger;

    public FileMqController(ILogger<FileMqController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMessages")]
    public IEnumerable<WeatherForecast> GetMessages()
    {
        return new List<>;
    }
}
