using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceE
{
    private ConfigResolver m_configResolver { get; set; }

    public ServiceE(ConfigResolver configResolver)
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
}
