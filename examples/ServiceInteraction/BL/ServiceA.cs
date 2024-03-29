﻿using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;

namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// Represents service A.
/// </summary>
/// <remarks>Initiates communication with the following services: B, E.</remarks>
public class ServiceA : IImplicitService
{
    private LoggingDAL m_loggingDAL { get; set; }
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ServiceA(
        LoggingDAL loggingDAL, 
        IServiceProvider serviceProvider)
    {
        m_loggingDAL = loggingDAL;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Method to call service B.
    /// </summary>
    public void CallServiceB()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        // Get data from DB.
        var nextState = "ServiceB";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL." + nextState;
        var methodName = "ProcessServiceA";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, null);

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to call service E.
    /// </summary>
    public void CallServiceE()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        string nextState = "ServiceE";
        var className = "WorkflowLib.Examples.ServiceInteraction.BL." + nextState;
        var methodName = "ProcessServiceA";

        // Invoke next service using reflection.
        var type = Type.GetType(className);
        var instance = m_serviceProvider.GetRequiredService(type);
        type.GetMethod(methodName).Invoke(instance, null);
        
        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method to call the next service depending on the current state of the process.
    /// </summary>
    public void CallNextService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        CallServiceE();
        CallServiceB();

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }

    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public void ProcessPreviousService()
    {
        var sourceName = this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name;
        m_loggingDAL.AddDbgLog(sourceName, "started");

        // Start wi, wti, bp, bt.
        var processName = "Delivering of the order";

        CallNextService();

        m_loggingDAL.AddDbgLog(sourceName, "finished");
    }
}