using Microsoft.AspNetCore.Mvc;

namespace WorkflowLib.Examples.ServiceInteraction.Webapi.Customer.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "MakeOrder")]
    public string MakeOrder(string info)
    {
        return "Stab: MakeOrder";
    }

    [HttpGet(Name = "GetOrderStatus")]
    public string GetOrderStatus()
    {
        return "Stab: GetOrderStatus";
    }
}
