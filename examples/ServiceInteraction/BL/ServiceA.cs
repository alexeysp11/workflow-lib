using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceA
{
    private ConfigResolver _configResolver { get; set; }

    public ServiceA(ConfigResolver configResolver)
    {
        _configResolver = configResolver;
    }

    public string CallServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        _configResolver.AddDbgLog(sourceName, "started");

        string responseE = CallServiceE();
        _configResolver.AddDbgLog(sourceName, "responseE: " + responseE);

        _configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallServiceE()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        _configResolver.AddDbgLog(sourceName, "started");
        
        _configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallNextService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        _configResolver.AddDbgLog(sourceName, "started");

        _configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }
}
