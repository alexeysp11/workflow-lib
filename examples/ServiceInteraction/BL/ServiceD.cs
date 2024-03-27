using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service D.
/// </summary>
/// <remarks>Initiates communication with the following services: B.</remarks>
public class ServiceD : IImplicitService
{
    private LoggingDAL m_loggingDAL { get; set; }
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceD(
        LoggingDAL loggingDAL, 
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to process service B.
    /// </summary>
    public string ProcessServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");
        
        CallServiceB();

        m_loggingDAL.AddDbgLog(sourceName, "finished");

        return "";
    }

    /// <summary>
    /// Method to call service B.
    /// </summary>
    public string CallServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");
        
        // Get data from DB.
        var nextState = "ServiceB";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL." + nextState;
        var methodName = "ProcessServiceD";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, null);

        m_loggingDAL.AddDbgLog(sourceName, "finished");

        return "";
    }

    /// <summary>
    /// Method to call the next service depending on the current state of the process.
    /// </summary>
    public string CallNextService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        m_loggingDAL.AddDbgLog(sourceName, "finished");

        return "";
    }
    
    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public string ProcessPreviousService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        m_loggingDAL.AddDbgLog(sourceName, "finished");

        return "";
    }
}
