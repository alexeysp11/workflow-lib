using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.ServiceRegistry;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.DAL;
using VelocipedeUtils.Shared.Models.Business.Processes;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents kitchen controller.
/// </summary>
/// <remarks>Initiates communication with the following services: B.</remarks>
public class KitchenBLController : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private IEsbServiceRegistry m_esbServiceRegistry;
    private readonly IServiceProvider m_serviceProvider;
    private WorkflowInstance? m_workflowInstance;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public KitchenBLController(
        ILoggingDAL loggingDAL,
        IEsbServiceRegistry esbServiceRegistry,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_esbServiceRegistry = esbServiceRegistry;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to process warehouse controller.
    /// </summary>
    public void ProcessWarehouseController(ref long workflowInstanceId, ref long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        if (m_workflowInstance == null)
            m_workflowInstance = m_esbServiceRegistry.GetWorkflowInstanceById(workflowInstanceId);
        m_esbServiceRegistry.CreateBusinessTaskByWI(m_workflowInstance, "KitchenBLController-WarehouseBLController", transitionId);
        
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
                case 2:
                    ProcessWarehouseController(ref workflowInstanceId, ref transitionId);
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