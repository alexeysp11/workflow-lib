using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.ServiceRegistry;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service D.
/// </summary>
/// <remarks>Initiates communication with the following services: B.</remarks>
public class ServiceD : IImplicitService
{
    private LoggingDAL m_loggingDAL;
    private EsbServiceRegistry m_endpointServiceResolver;
    private WorkflowInstance m_workflowInstance;
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceD(
        LoggingDAL loggingDAL,
        EsbServiceRegistry endpointServiceResolver,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_endpointServiceResolver = endpointServiceResolver;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to process service B.
    /// </summary>
    public void ProcessServiceB(long workflowInstanceId, long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");
        
        try
        {
            if (m_workflowInstance == null)
                m_workflowInstance = m_endpointServiceResolver.GetWorkflowInstanceById(workflowInstanceId);
            m_endpointServiceResolver.CreateBusinessTaskByWI(m_workflowInstance, "ServiceD-ServiceB", transitionId);
            CallServiceB();
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to call service B.
    /// </summary>
    public void CallServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");
        
        // Get data from DB.
        var nextState = "ServiceB";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL." + nextState;
        var methodName = "ProcessPreviousService";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, new object[]{m_workflowInstance.Id, 3});

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
            case 2:
                ProcessServiceB(workflowInstanceId, transitionId);
                break;
            default:
                throw new System.Exception($"Incorrect transition ID: {transitionId}");
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}