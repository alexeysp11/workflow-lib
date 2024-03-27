using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service C.
/// </summary>
/// <remarks>Does not initiate communication with any service.</remarks>
public class ServiceC : IImplicitService
{
    private LoggingDAL m_loggingDAL { get; set; }
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceC(
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
