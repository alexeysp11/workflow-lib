using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceE
{
    private ConfigResolver _configResolver { get; set; }

    public ServiceE(ConfigResolver configResolver)
    {
        _configResolver = configResolver;
    }

    public string ProcessServiceA()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        _configResolver.AddDbgLog(sourceName, "started");

        _configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }
}
