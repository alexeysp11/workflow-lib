using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.ServiceInteraction.Core.Routing;
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
        private readonly ILogger<EmployeeController> m_logger;
        private EsbControlPlane m_controlPlane;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EmployeeController(
            ILogger<EmployeeController> logger,
            EsbControlPlane controlPlane)
        {
            m_logger = logger;
            m_controlPlane = controlPlane;
        }

        /// <summary>
        /// Get a list of all business processes.
        /// </summary>
        [HttpGet("GetBusinessProcesses", Name = "GetBusinessProcesses")]
        public List<BusinessProcess> GetBusinessProcesses(long userId)
        {
            return m_controlPlane.GetBusinessProcesses(userId);
        }

        /// <summary>
        /// Get a list of workflow instances of the specified business process.
        /// </summary>
        [HttpGet("GetWorkflowInstances", Name = "GetWorkflowInstances")]
        public List<WorkflowInstance> GetWorkflowInstances(long businessProcessId)
        {
            return m_controlPlane.GetWorkflowInstances(businessProcessId);
        }
        
        /// <summary>
        /// Get the status of a workflow instance.
        /// </summary>
        [HttpGet("GetWorkflowInstanceStatus", Name = "GetWorkflowInstanceStatus")]
        public string GetWorkflowInstanceStatus(long workflowInstanceId)
        {
            return m_controlPlane.GetWorkflowInstanceStatus(workflowInstanceId);
        }
        
        /// <summary>
        /// Get the workflow instance details.
        /// </summary>
        [HttpGet("GetWorkflowInstanceDetails", Name = "GetWorkflowInstanceDetails")]
        public BusinessProcessState GetWorkflowInstanceDetails(long workflowInstanceId)
        {
            return m_controlPlane.GetWorkflowInstanceDetails(workflowInstanceId);
        }
        
        /// <summary>
        /// Get the current task for a specific workflow instance.
        /// </summary>
        [HttpGet("GetCurrentTask", Name = "GetCurrentTask")]
        public BusinessTask GetCurrentTask(long workflowInstanceId)
        {
            return m_controlPlane.GetCurrentTask(workflowInstanceId);
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