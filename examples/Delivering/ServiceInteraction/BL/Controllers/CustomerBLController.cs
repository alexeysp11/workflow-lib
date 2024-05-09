using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;
using WorkflowLib.ServiceDiscoveryBpm.ServiceRegistry;
using WorkflowLib.ServiceDiscoveryBpm.DAL;
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
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public void MoveWorkflowInstanceNext(PipeDelegateParams parameters)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        var workflowInstanceId = parameters.WorkflowInstanceId;
        var transitionId = parameters.BPStateTransitionId;
        var initialOrder = parameters.InitialOrder;
        try
        {
            if (initialOrder == null)
                throw new System.Exception("Initial order could not be null");
            m_esbServiceRegistry.SaveInitialOrder(initialOrder);
            
            m_workflowInstance = m_esbServiceRegistry.CreateInitialWI("Delivering of the order", "CustomerBLController");           
            workflowInstanceId = m_workflowInstance.Id;
            
            // Invoke file service using reflection.
            string nextState = "FileService";
            var className = "WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers." + nextState;
            var methodName = "ProcessCustomerControllerBL";
            var type = Type.GetType(className);
            var instance = m_serviceProvider.GetRequiredService(type);
            type.GetMethod(methodName).Invoke(instance, null);

            var businessTask = m_esbServiceRegistry.CreateBusinessTaskByWI(m_workflowInstance, "CustomerBLController-WarehouseBLController", 1, false);
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