using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.ServiceRegistry;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents warehouse controller.
/// </summary>
/// <remarks>Initiates communication with the following services: C, D.</remarks>
public class WarehouseBLController : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private IEsbServiceRegistry m_endpointServiceResolver;
    private readonly IServiceProvider m_serviceProvider;
    private WorkflowInstance? m_workflowInstance;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public WarehouseBLController(
        ILoggingDAL loggingDAL,
        IEsbServiceRegistry endpointServiceResolver,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_endpointServiceResolver = endpointServiceResolver;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to process customer controller.
    /// </summary>
    public void ProcessCustomerControllerBL(ref long workflowInstanceId, ref long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        try
        {
            if (m_workflowInstance == null)
                m_workflowInstance = m_endpointServiceResolver.GetWorkflowInstanceById(workflowInstanceId);
            m_endpointServiceResolver.CreateBusinessTaskByWI(m_workflowInstance, "WarehouseBLController-KitchenBLController", transitionId);
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to process kitchen controller.
    /// </summary>
    public void ProcessKitchenController(ref long workflowInstanceId, ref long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        try
        {
            if (m_workflowInstance == null)
                m_workflowInstance = m_endpointServiceResolver.GetWorkflowInstanceById(workflowInstanceId);
            m_endpointServiceResolver.CreateBusinessTaskByWI(m_workflowInstance, "WarehouseBLController-CourierBLController", transitionId);
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
    public void ProcessPreviousService(ref long workflowInstanceId, ref long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

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

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}