using System.Reflection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

public class ServiceB
{
    private ConfigResolver _configResolver { get; set; }

    public ServiceB(ConfigResolver configResolver)
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

    public string ProcessServiceD()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        _configResolver.AddDbgLog(sourceName, "started");

        _configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallServiceC()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        _configResolver.AddDbgLog(sourceName, "started");

        _configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    public string CallServiceD()
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
