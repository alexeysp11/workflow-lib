using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service A.
/// </summary>
/// <remarks>Initiates communication with the following services: B, E.</remarks>
public class ServiceA : IImplicitService
{
    private ConfigResolver m_configResolver { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceA(ConfigResolver configResolver)
    {
        m_configResolver = configResolver;
    }

    /// <summary>
    /// Method to call service B.
    /// </summary>
    public string CallServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        string responseE = CallServiceE();
        m_configResolver.AddDbgLog(sourceName, "responseE: " + responseE);

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    /// <summary>
    /// Method to call service E.
    /// </summary>
    public string CallServiceE()
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
