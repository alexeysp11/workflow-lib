using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.ServiceInteraction.Webapi.Customer;
using WorkflowLib.Models.Business.BusinessDocuments;

namespace WorkflowLib.Examples.ServiceInteraction.Webapi.Customer.Controllers;

/// <summary>
/// Controller for processing customer requests.
/// </summary>
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private IStartupInstance _startupInstance;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public CustomerController(
        ILogger<CustomerController> logger,
        IStartupInstance startupInstance)
    {
        _logger = logger;
        _startupInstance = startupInstance;
    }

    /// <summary>
    /// Start order processing.
    /// </summary>
    [HttpPost(Name = "MakeOrder")]
    public string MakeOrder(InitialOrder initialOrder)
    {
        _startupInstance.Run();
        return "Stab: MakeOrder";
    }

    /// <summary>
    /// Get order processing status.
    /// </summary>
    [HttpGet(Name = "GetOrderStatus")]
    public string GetOrderStatus()
    {
        return "Stab: GetOrderStatus";
    }
}
