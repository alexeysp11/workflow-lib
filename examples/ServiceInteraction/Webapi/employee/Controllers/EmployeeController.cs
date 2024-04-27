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

        [HttpPost("GetProcesses", Name = "GetProcesses")]
        public string GetProcesses(string info)
        {
            return "Stab: GetProcesses";
        }

        [HttpPost("GetWorkflowInstances", Name = "GetWorkflowInstances")]
        public string GetWorkflowInstances(string info)
        {
            return "Stab: GetWorkflowInstances";
        }
        
        [HttpPost("GetWorkflowInstanceStatus", Name = "GetWorkflowInstanceStatus")]
        public string GetWorkflowInstanceStatus(string info)
        {
            return "Stab: GetWorkflowInstanceStatus";
        }
        
        [HttpPost("GetWorkflowInstanceDetails", Name = "GetWorkflowInstanceDetails")]
        public string GetWorkflowInstanceDetails(string info)
        {
            return "Stab: GetWorkflowInstanceDetails";
        }
        
        [HttpPost("GetCurrentTask", Name = "GetCurrentTask")]
        public string GetCurrentTask(string info)
        {
            return "Stab: GetCurrentTask";
        }

        [HttpPost("MoveWorkflowInstanceNext", Name = "MoveWorkflowInstanceNext")]
        public string MoveWorkflowInstanceNext(string info)
        {
            return "Stab: MoveWorkflowInstanceNext";
        }
    }
}
