using Microsoft.AspNetCore.Mvc;

namespace WorkflowLib.Examples.ServiceInteraction.Webapi.Employee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpPost("ProcessPreviousService", Name = "ProcessPreviousService")]
        public string ProcessPreviousService(string info)
        {
            return "Stab: ProcessPreviousService";
        }

        [HttpPost("CallNextService", Name = "CallNextService")]
        public string CallNextService(string info)
        {
            return "Stab: CallNextService";
        }
        
        [HttpPost("GetBusinessProcessStatus", Name = "GetBusinessProcessStatus")]
        public string GetBusinessProcessStatus(string info)
        {
            return "Stab: GetBusinessProcessStatus";
        }
        
        [HttpPost("GetBusinessProcessDetails", Name = "GetBusinessProcessDetails")]
        public string GetBusinessProcessDetails(string info)
        {
            return "Stab: GetBusinessProcessDetails";
        }
    }
}
