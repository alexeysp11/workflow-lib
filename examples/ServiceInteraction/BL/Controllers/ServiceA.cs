using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.ServiceRegistry;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents service A.
/// </summary>
/// <remarks>Initiates communication with the following services: B, E.</remarks>
public class ServiceA : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private EsbServiceRegistry m_endpointServiceResolver;
    private WorkflowInstance m_workflowInstance;
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceA(
        ILoggingDAL loggingDAL,
        EsbServiceRegistry endpointServiceResolver,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_endpointServiceResolver = endpointServiceResolver;
        m_serviceProvider = serviceProvider;
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
        var className = "WorkflowLib.Examples.ServiceInteraction.BL.Controllers." + nextState;
        var methodName = "ProcessPreviousService";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, new object[]{m_workflowInstance.Id, 1});

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to call service E.
    /// </summary>
    public void CallServiceE()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        string nextState = "ServiceE";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL.Controllers." + nextState;
        var methodName = "ProcessServiceA";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, null);
        
        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to call the next service depending on the current state of the process.
    /// </summary>
    public void CallNextService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        try
        {
            CallServiceE();

            m_endpointServiceResolver.CreateBusinessTaskByWI(m_workflowInstance, "ServiceA-ServiceB", 1, false);
            CallServiceB();
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public void ProcessPreviousService(long workflowInstanceId = 0, long transitionId = 0)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        try
        {
            m_workflowInstance = m_endpointServiceResolver.CreateInitialWI("Delivering of the order", "ServiceA");           
            CallNextService();
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}