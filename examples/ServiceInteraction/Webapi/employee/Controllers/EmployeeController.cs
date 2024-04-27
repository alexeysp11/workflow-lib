using Microsoft.AspNetCore.Mvc;

namespace WorkflowLib.Examples.ServiceInteraction.Webapi.Employee.Controllers
{
    /// <summary>
    /// Controller for processing employee requests.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get a list of all business processes.
        /// </summary>
        [HttpPost("GetProcesses", Name = "GetProcesses")]
        public string GetProcesses(string info)
        {
            return "Stab: GetProcesses";
        }

        /// <summary>
        /// Get a list of workflow instances of the specified business process.
        /// </summary>
        [HttpPost("GetWorkflowInstances", Name = "GetWorkflowInstances")]
        public string GetWorkflowInstances(string info)
        {
            return "Stab: GetWorkflowInstances";
        }
        
        /// <summary>
        /// Get the status of a workflow instance.
        /// </summary>
        [HttpPost("GetWorkflowInstanceStatus", Name = "GetWorkflowInstanceStatus")]
        public string GetWorkflowInstanceStatus(string info)
        {
            return "Stab: GetWorkflowInstanceStatus";
        }
        
        /// <summary>
        /// Get the workflow instance details.
        /// </summary>
        [HttpPost("GetWorkflowInstanceDetails", Name = "GetWorkflowInstanceDetails")]
        public string GetWorkflowInstanceDetails(string info)
        {
            return "Stab: GetWorkflowInstanceDetails";
        }
        
        /// <summary>
        /// Get the current task for a specific workflow instance.
        /// </summary>
        [HttpPost("GetCurrentTask", Name = "GetCurrentTask")]
        public string GetCurrentTask(string info)
        {
            return "Stab: GetCurrentTask";
        }

        /// <summary>
        /// Move a workflow instance to the next state.
        /// </summary>
        [HttpPost("MoveWorkflowInstanceNext", Name = "MoveWorkflowInstanceNext")]
        public string MoveWorkflowInstanceNext(string info)
        {
            return "Stab: MoveWorkflowInstanceNext";
        }
    }
}
