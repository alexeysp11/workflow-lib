using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;

namespace WorkflowLib.Examples.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents service E.
/// </summary>
/// <remarks>Does not initiate communication with any service.</remarks>
public class ServiceE
{
    private ILoggingDAL m_loggingDAL;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceE(
        ILoggingDAL loggingDAL)
    {
        m_loggingDAL = loggingDAL;
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