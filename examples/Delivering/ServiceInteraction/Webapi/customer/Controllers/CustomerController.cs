using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Webapi.Customer;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Monetary;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.Webapi.Customer.Controllers
{
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
        [HttpPost("MakeOrder", Name = "MakeOrder")]
        public string MakeOrder(InitialOrder initialOrder)
        {
            _startupInstance.Run();
            return "Stab: MakeOrder";
        }

        /// <summary>
        /// Pay for registered order.
        /// </summary>
        [HttpPost("MakePayment", Name = "MakePayment")]
        public string MakePayment(Payment payment)
        {
            return "Stab: MakePayment";
        }

        /// <summary>
        /// Get order processing status.
        /// </summary>
        [HttpGet("GetOrderStatus", Name = "GetOrderStatus")]
        public string GetOrderStatus()
        {
            return "Stab: GetOrderStatus";
        }
    }
}