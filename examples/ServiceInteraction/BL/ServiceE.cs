using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service E.
/// </summary>
/// <remarks>Does not initiate communication with any service.</remarks>
public class ServiceE : IImplicitService
{
    private ConfigResolver m_configResolver { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceE(ConfigResolver configResolver)
    {
        m_configResolver = configResolver;
    }

    /// <summary>
    /// Method to process service A.
    /// </summary>
    public string ProcessServiceA()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    /// <summary>
    /// Method to call the next service depending on the current state of the process.
    /// </summary>
    public string CallNextService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public string ProcessPreviousService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }
}
