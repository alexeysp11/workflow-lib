using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.ServiceRegistry;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents customer controller.
/// </summary>
/// <remarks>Initiates communication with the following services: B, E.</remarks>
public class CustomerController : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private IEsbServiceRegistry m_endpointServiceResolver;
    private readonly IServiceProvider m_serviceProvider;
    private WorkflowInstance? m_workflowInstance;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public CustomerController(
        ILoggingDAL loggingDAL,
        IEsbServiceRegistry endpointServiceResolver,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_endpointServiceResolver = endpointServiceResolver;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to call warehouse controller.
    /// </summary>
    public void CallWarehouseController()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        // Get data from DB.
        var nextState = "WarehouseController";
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

        string nextState = "FileService";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL.Controllers." + nextState;
        var methodName = "ProcessCustomerController";

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

            m_endpointServiceResolver.CreateBusinessTaskByWI(m_workflowInstance, "CustomerController-WarehouseController", 1, false);
            // CallWarehouseController();
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
    public void ProcessPreviousService(ref long workflowInstanceId, ref long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        try
        {
            m_workflowInstance = m_endpointServiceResolver.CreateInitialWI("Delivering of the order", "CustomerController");           
            workflowInstanceId = m_workflowInstance.Id;
            CallNextService();
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}