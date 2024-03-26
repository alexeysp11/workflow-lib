using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service B.
/// </summary>
/// <remarks>Initiates communication with the following services: C, D.</remarks>
public class ServiceB : IImplicitService
{
    private ConfigResolver m_configResolver { get; set; }
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceB(
        ConfigResolver configResolver, 
        IServiceProvider serviceProvider)
    {
        m_configResolver = configResolver;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to process service A.
    /// </summary>
    public string ProcessServiceA()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        CallServiceD();

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    /// <summary>
    /// Method to process service D.
    /// </summary>
    public string ProcessServiceD()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        CallServiceC();

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    /// <summary>
    /// Method to call service C.
    /// </summary>
    public string CallServiceC()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");
        
        // Get data from DB.
        var nextState = "ServiceC";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL." + nextState;
        var methodName = "ProcessServiceB";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, null);

        m_configResolver.AddDbgLog(sourceName, "finished");

        return "";
    }

    /// <summary>
    /// Method to call service D.
    /// </summary>
    public string CallServiceD()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_configResolver.AddDbgLog(sourceName, "started");

        // Get data from DB.
        var nextState = "ServiceD";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL." + nextState;
        var methodName = "ProcessServiceB";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, null);

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
