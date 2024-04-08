using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;

namespace WorkflowLib.Examples.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents courier controller.
/// </summary>
/// <remarks>Does not initiate communication with any service.</remarks>
public class CourierController : IImplicitService
{
    private ILoggingDAL m_loggingDAL;
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public CourierController(
        ILoggingDAL loggingDAL,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to process warehouse controller.
    /// </summary>
    public void ProcessWarehouseController(long workflowInstanceId, long transitionId)
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

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
            case 4:
                ProcessWarehouseController(workflowInstanceId, transitionId);
                break;
            default:
                throw new System.Exception($"Incorrect transition ID: {transitionId}");
        }

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}