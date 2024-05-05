using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.ServiceRegistry;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.DAL;
using WorkflowLib.Models.Business.Processes;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents customer controller.
/// </summary>
/// <remarks>Initiates communication with the following services: B, E.</remarks>
public class CustomerBLController : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private IEsbServiceRegistry m_esbServiceRegistry;
    private readonly IServiceProvider m_serviceProvider;
    private WorkflowInstance? m_workflowInstance;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public CustomerBLController(
        ILoggingDAL loggingDAL,
        IEsbServiceRegistry esbServiceRegistry,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_esbServiceRegistry = esbServiceRegistry;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to call file service.
    /// </summary>
    public void CallFileService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        string nextState = "FileService";
        var className = "WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers." + nextState;
        var methodName = "ProcessCustomerControllerBL";

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
            CallFileService();

            m_esbServiceRegistry.CreateBusinessTaskByWI(m_workflowInstance, "CustomerBLController-WarehouseBLController", 1, false);
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
    public void MoveWorkflowInstanceNext(PipeDelegateParams parameters)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        var workflowInstanceId = parameters.WorkflowInstanceId;
        var transitionId = parameters.BPStateTransitionId;
        try
        {
            m_workflowInstance = m_esbServiceRegistry.CreateInitialWI("Delivering of the order", "CustomerBLController");           
            workflowInstanceId = m_workflowInstance.Id;
            CallNextService();
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
        }
        parameters.WorkflowInstanceId = workflowInstanceId;
        parameters.BPStateTransitionId = transitionId;

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}