using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceC
{
    private ConfigResolver m_configResolver { get; set; }

    public ServiceC(ConfigResolver configResolver)
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
}
