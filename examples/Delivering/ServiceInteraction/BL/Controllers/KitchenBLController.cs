using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;
using WorkflowLib.ServiceDiscoveryBpm.ServiceRegistry;
using WorkflowLib.ServiceDiscoveryBpm.DAL;
using WorkflowLib.Models.Business.Processes;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers;

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
        
        try
        {
            if (m_workflowInstance == null)
                m_workflowInstance = m_esbServiceRegistry.GetWorkflowInstanceById(workflowInstanceId);
            m_esbServiceRegistry.CreateBusinessTaskByWI(m_workflowInstance, "KitchenBLController-WarehouseBLController", transitionId);
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to call the next service depending on the current state of the process.
    /// </summary>
    public void CallNextService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
    
    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public void MoveWorkflowInstanceNext(PipeDelegateParams parameters)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

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
}