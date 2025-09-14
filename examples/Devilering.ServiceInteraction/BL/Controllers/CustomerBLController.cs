using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DAL;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.ServiceRegistry;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.DAL;
using VelocipedeUtils.Shared.Models.Business.Processes;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents customer controller.
/// </summary>
/// <remarks>Initiates communication with the following services: B, E.</remarks>
public class CustomerBLController : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private DeliveryOrderDAL m_deliveryOrderDAL;
    private IEsbServiceRegistry m_esbServiceRegistry;
    private readonly IServiceProvider m_serviceProvider;
    private WorkflowInstance? m_workflowInstance;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public CustomerBLController(
        ILoggingDAL loggingDAL,
        DeliveryOrderDAL deliveryOrderDAL,
        IEsbServiceRegistry esbServiceRegistry,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_deliveryOrderDAL = deliveryOrderDAL;
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
        var initialOrder = parameters.InitialOrder;
        try
        {
            if (initialOrder == null)
                throw new System.Exception("Initial order could not be null");
            m_deliveryOrderDAL.SaveInitialOrder(initialOrder);
            
            m_workflowInstance = m_esbServiceRegistry.CreateInitialWI("Delivering of the order", "CustomerBLController");           
            workflowInstanceId = m_workflowInstance.Id;
            
            // Invoke file service using reflection.
            string nextState = "FileService";
            var className = "VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Controllers." + nextState;
            var methodName = "ProcessCustomerControllerBL";
            var type = Type.GetType(className);
            var instance = m_serviceProvider.GetRequiredService(type);
            type.GetMethod(methodName).Invoke(instance, null);

            var businessTask = m_esbServiceRegistry.CreateBusinessTaskByWI(m_workflowInstance, "CustomerBLController-WarehouseBLController", 1, false);
            
            parameters.WorkflowInstanceId = workflowInstanceId;
            
            m_loggingDAL.AddDbgLog(sourceName, "finished");
        }
        catch (System.Exception ex)
        {
            m_loggingDAL.AddDbgLog(sourceName, ex.ToString());
            throw;
        }
    }
}