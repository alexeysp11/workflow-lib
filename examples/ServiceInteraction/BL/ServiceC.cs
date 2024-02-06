using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceC
{
    private ConfigResolver _configResolver { get; set; }

    public ServiceC(ConfigResolver configResolver)
    {
        _configResolver = configResolver;
    }

    public string ProcessServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        _configResolver.AddDbgLog(sourceName, "started");

        _configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }
}
