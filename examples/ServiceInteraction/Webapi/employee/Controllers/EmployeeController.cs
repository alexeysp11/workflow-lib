using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Core.Routing;
using WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Models;
using WorkflowLib.Examples.ServiceInteraction.Webapi.Employee;

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
        private IStartupInstance _startupInstance;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EmployeeController(
            ILogger<EmployeeController> logger,
            IStartupInstance startupInstance,
            EsbControlPlane controlPlane)
        {
            m_logger = logger;
            m_controlPlane = controlPlane;
            _startupInstance = startupInstance;
        }

        /// <summary>
        /// Get a list of all business processes.
        /// </summary>
        [HttpGet("GetBusinessProcesses", Name = "GetBusinessProcesses")]
        public List<BusinessProcess> GetBusinessProcesses(
            long userId)
        {
            return m_controlPlane.GetBusinessProcesses(userId);
        }

        /// <summary>
        /// Get a list of workflow instances of the specified business process.
        /// </summary>
        [HttpGet("GetWorkflowInstances", Name = "GetWorkflowInstances")]
        public List<WorkflowInstance> GetWorkflowInstances(
            long businessProcessId)
        {
            return m_controlPlane.GetWorkflowInstances(businessProcessId);
        }
        
        /// <summary>
        /// Get the workflow instance by its ID.
        /// </summary>
        [HttpGet("GetWorkflowInstanceById", Name = "GetWorkflowInstanceById")]
        public WorkflowInstance GetWorkflowInstanceById(
            long workflowInstanceId)
        {
            return m_controlPlane.GetWorkflowInstanceById(workflowInstanceId);
        }
        
        /// <summary>
        /// Get the current task for a specific workflow instance.
        /// </summary>
        [HttpGet("GetCurrentTask", Name = "GetCurrentTask")]
        public BusinessTask GetCurrentTask(
            long workflowInstanceId)
        {
            return m_controlPlane.GetCurrentTask(workflowInstanceId);
        }

        /// <summary>
        /// Move a workflow instance to the next state.
        /// </summary>
        [HttpPost("MoveWorkflowInstanceNext", Name = "MoveWorkflowInstanceNext")]
        public string MoveWorkflowInstanceNext(
            long workflowInstanceId, 
            long businessTaskId)
        {
            _startupInstance.Run();
            var transition = m_controlPlane.GetTransitionByTaskId(businessTaskId);
            if (transition == null)
                throw new System.Exception($"Transition could not be null (workflowInstanceId: {workflowInstanceId}, businessTaskId: {businessTaskId})");
            var parameters = new ValueProcessingPipeDelegateParams
            {
                WorkflowInstanceId = workflowInstanceId,
                BusinessProcessStateTransitionId = transition.Id,
                UserId = 1
            };
            m_controlPlane.MoveWorkflowInstanceNext(parameters);
            return "Executed";
        }
    }
}