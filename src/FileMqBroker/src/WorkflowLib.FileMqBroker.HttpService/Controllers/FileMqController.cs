using Microsoft.AspNetCore.Mvc;
using WorkflowLib.FileMqBroker.MqLibrary;
using WorkflowLib.FileMqBroker.MqLibrary.Models;

namespace WorkflowLib.FileMqBroker.HttpService.Controllers;

[ApiController]
[Route("[controller]")]
public class FileMqController : ControllerBase
{
    private readonly ILogger<FileMqController> _logger;
    private readonly AppSettings _appSettings;

    public FileMqController(ILogger<FileMqController> logger, AppSettings appSettings)
    {
        _logger = logger;
        _appSettings = appSettings;
    }

    [HttpPost(Name = "ProcessMessage")]
    public string ProcessMessage(string request, string queueName)
    {
        return RequestProcessing.ProcessMessage(
            request,
            queueName,
            "GET",
            "FileMq/ProcessMessage",
            _appSettings);
    }
}
