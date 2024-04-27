using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.ServiceInteraction.Models;

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
        [HttpGet("GetBusinessProcesses", Name = "GetBusinessProcesses")]
        public List<BusinessProcess> GetBusinessProcesses(long userId)
        {
            return new List<BusinessProcess>();
        }

        /// <summary>
        /// Get a list of workflow instances of the specified business process.
        /// </summary>
        [HttpGet("GetWorkflowInstances", Name = "GetWorkflowInstances")]
        public List<WorkflowInstance> GetWorkflowInstances(long businessProcessId)
        {
            return new List<WorkflowInstance>();
        }
        
        /// <summary>
        /// Get the status of a workflow instance.
        /// </summary>
        [HttpGet("GetWorkflowInstanceStatus", Name = "GetWorkflowInstanceStatus")]
        public string GetWorkflowInstanceStatus(long workflowInstanceId)
        {
            return BusinessEntityStatus.Active.ToString();
        }
        
        /// <summary>
        /// Get the workflow instance details.
        /// </summary>
        [HttpGet("GetWorkflowInstanceDetails", Name = "GetWorkflowInstanceDetails")]
        public BusinessProcessState GetWorkflowInstanceDetails(long workflowInstanceId)
        {
            return new BusinessProcessState();
        }
        
        /// <summary>
        /// Get the current task for a specific workflow instance.
        /// </summary>
        [HttpGet("GetCurrentTask", Name = "GetCurrentTask")]
        public BusinessTask GetCurrentTask(long workflowInstanceId)
        {
            return new BusinessTask();
        }

        /// <summary>
        /// Move a workflow instance to the next state.
        /// </summary>
        [HttpPost("MoveWorkflowInstanceNext", Name = "MoveWorkflowInstanceNext")]
        public string MoveWorkflowInstanceNext(long workflowInstanceId)
        {
            return "Stab: MoveWorkflowInstanceNext";
        }
    }
}
