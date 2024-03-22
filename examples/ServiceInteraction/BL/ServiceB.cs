using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceB
{
    private ConfigResolver m_configResolver { get; set; }

    public ServiceB(ConfigResolver configResolver)
    {
        m_configResolver = configResolver;
    }

    public string ProcessServiceA()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string ProcessServiceD()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallServiceC()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallServiceD()
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
