using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceD
{
    private ConfigResolver m_configResolver { get; set; }

    public ServiceD(ConfigResolver configResolver)
    {
        m_configResolver = configResolver;
    }

    public string ProcessServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallServiceB()
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
