using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service E.
/// </summary>
/// <remarks>Does not initiate communication with any service.</remarks>
public class ServiceE
{
    private LoggingDAL m_loggingDAL;
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceE(
        LoggingDAL loggingDAL,
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to process service A.
    /// </summary>
    public void ProcessServiceA()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}