using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;
using WorkflowLib.Shared.ServiceDiscoveryBpm.ServiceRegistry;
using WorkflowLib.Shared.ServiceDiscoveryBpm.DAL;
using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents warehouse controller.
/// </summary>
/// <remarks>Initiates communication with the following services: C, D.</remarks>
public class WarehouseBLController : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private IEsbServiceRegistry m_esbServiceRegistry;
    private readonly IServiceProvider m_serviceProvider;
    private WorkflowInstance? m_workflowInstance;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public WarehouseBLController(
        ILoggingDAL loggingDAL,
        IEsbServiceRegistry esbServiceRegistry,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_esbServiceRegistry = esbServiceRegistry;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to process customer controller.
    /// </summary>
    public void ProcessCustomerControllerBL(ref long workflowInstanceId, ref long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        if (m_workflowInstance == null)
            m_workflowInstance = m_esbServiceRegistry.GetWorkflowInstanceById(workflowInstanceId);
        m_esbServiceRegistry.CreateBusinessTaskByWI(m_workflowInstance, "WarehouseBLController-KitchenBLController", transitionId);
        
        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to process kitchen controller.
    /// </summary>
    public void ProcessKitchenController(ref long workflowInstanceId, ref long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        if (m_workflowInstance == null)
            m_workflowInstance = m_esbServiceRegistry.GetWorkflowInstanceById(workflowInstanceId);
        m_esbServiceRegistry.CreateBusinessTaskByWI(m_workflowInstance, "WarehouseBLController-CourierBLController", transitionId);

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
    
    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public void MoveWorkflowInstanceNext(PipeDelegateParams parameters)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        try
        {
            var workflowInstanceId = parameters.WorkflowInstanceId;
            var transitionId = parameters.BPStateTransitionId;
            switch (transitionId)
            {
                case 1:
                    ProcessCustomerControllerBL(ref workflowInstanceId, ref transitionId);
                    break;
                case 3:
                    ProcessKitchenController(ref workflowInstanceId, ref transitionId);
                    break;
                default:
                    throw new System.Exception($"Incorrect transition ID: {transitionId}");
            }
            parameters.WorkflowInstanceId = workflowInstanceId;
            parameters.BPStateTransitionId = transitionId;

            m_loggingDAL.AddDbgLog(sourceName, "finished");
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
            throw;
        }
    }
}