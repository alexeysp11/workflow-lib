using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service C.
/// </summary>
/// <remarks>Does not initiate communication with any service.</remarks>
public class ServiceC : IImplicitService
{
    private ConfigResolver m_configResolver { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceC(ConfigResolver configResolver)
    {
        m_configResolver = configResolver;
    }

    /// <summary>
    /// Method to process service B.
    /// </summary>
    public string ProcessServiceB()
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
