using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.DAL;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Controllers;

/// <summary>
/// Represents service E.
/// </summary>
/// <remarks>Does not initiate communication with any service.</remarks>
public class FileService
{
    private ILoggingDAL m_loggingDAL;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public FileService(
        ILoggingDAL loggingDAL)
    {
        m_loggingDAL = loggingDAL;
    }

    /// <summary>
    /// Method to process customer controller.
    /// </summary>
    public void ProcessCustomerControllerBL()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}