using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceA
{
    private ConfigResolver m_configResolver { get; set; }

    public ServiceA(ConfigResolver configResolver)
    {
        m_configResolver = configResolver;
    }

    public string CallServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        string responseE = CallServiceE();
        m_configResolver.AddDbgLog(sourceName, "responseE: " + responseE);

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallServiceE()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");
        
        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallNextService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }
}
