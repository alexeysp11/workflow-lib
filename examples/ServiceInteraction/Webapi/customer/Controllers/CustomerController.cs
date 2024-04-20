using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.ServiceInteraction.Webapi.Customer;

namespace WorkflowLib.Examples.ServiceInteraction.Webapi.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private IStartupInstance _startupInstance;

    public CustomerController(
        ILogger<CustomerController> logger,
        IStartupInstance startupInstance)
    {
        _logger = logger;
        _startupInstance = startupInstance;
    }

    [HttpPost(Name = "MakeOrder")]
    public string MakeOrder(string info)
    {
        _startupInstance.Run();
        return "Stab: MakeOrder";
    }

    [HttpGet(Name = "GetOrderStatus")]
    public string GetOrderStatus()
    {
        return "Stab: GetOrderStatus";
    }
}
