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
public class WarehouseController : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private IEsbServiceRegistry m_endpointServiceResolver;
    private WorkflowInstance m_workflowInstance;
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public WarehouseController(
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
    public void ProcessCustomerController(long workflowInstanceId, long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        try
        {
            if (m_workflowInstance == null)
                m_workflowInstance = m_endpointServiceResolver.GetWorkflowInstanceById(workflowInstanceId);
            m_endpointServiceResolver.CreateBusinessTaskByWI(m_workflowInstance, "WarehouseController-KitchenController", transitionId);
            CallKitchenController();
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
    public void ProcessKitchenController(long workflowInstanceId, long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        try
        {
            if (m_workflowInstance == null)
                m_workflowInstance = m_endpointServiceResolver.GetWorkflowInstanceById(workflowInstanceId);
            m_endpointServiceResolver.CreateBusinessTaskByWI(m_workflowInstance, "WarehouseController-CourierController", transitionId);
            CallCourierController();
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to call courier controller.
    /// </summary>
    public void CallCourierController()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");
        
        // Get data from DB.
        var nextState = "CourierController";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL.Controllers." + nextState;
        var methodName = "ProcessPreviousService";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, new object[]{m_workflowInstance.Id, 4});

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to call kitchen controller.
    /// </summary>
    public void CallKitchenController()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        // Get data from DB.
        var nextState = "KitchenController";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL.Controllers." + nextState;
        var methodName = "ProcessPreviousService";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, new object[]{m_workflowInstance.Id, 2});

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
    public void ProcessPreviousService(long workflowInstanceId = 0, long transitionId = 0)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        switch (transitionId)
        {
            case 1:
                ProcessCustomerController(workflowInstanceId, transitionId);
                break;
            case 3:
                ProcessKitchenController(workflowInstanceId, transitionId);
                break;
            default:
                throw new System.Exception($"Incorrect transition ID: {transitionId}");
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}