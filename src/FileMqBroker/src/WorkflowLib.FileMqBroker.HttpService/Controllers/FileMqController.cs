using Microsoft.AspNetCore.Mvc;
using WorkflowLib.FileMqBroker.MqLibrary;

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

    [HttpGet(Name = "ProcessMessage")]
    public string ProcessMessage(string request, string queueName)
    {
        return RequestProcessing.ProcessMessage(request, queueName);
    }
}
