using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

/// <summary>
/// This class is responsible for interacting with configuration data 
/// about communication between system components.
/// </summary>
public class ConfigResolver
{
    private DbContextOptions<ServiceInteractionContext> _contextOptions { get; set; }

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public ConfigResolver(
        DbContextOptions<ServiceInteractionContext> contextOptions) 
    {
        _contextOptions = contextOptions;
    }

    /// <summary>
    /// A method that adds logs to the database.
    /// </summary>
    public void AddDbgLog(string sourceName, string sourceDetails)
    {
        using var context = new ServiceInteractionContext(_contextOptions);
        var dbglog = new DbgLog
        {
            SourceName = sourceName,
            SourceDetails = sourceDetails,
            CreateDate = System.DateTime.UtcNow,
            ChangeDate = System.DateTime.UtcNow
        };
        context.DbgLogs.Add(dbglog);
        context.SaveChanges();
    }

    /// <summary>
    /// 
    /// </summary>
    public void InitCommunicationConfigs()
    {
        using var context = new ServiceInteractionContext(_contextOptions);

        var dtNow = System.DateTime.UtcNow;

        // Process.
        var process = new BusinessProcess
        {
            Name = "Delivering of the order",
            DateCreated = dtNow
        };

        // Process states.
        var customer = new BusinessProcessState
        {
            Name = "Customer backend",
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var wh2kitchen = new BusinessProcessState
        {
            Name = "Warehouse backend (wh2kitchen)",
            BusinessProcess = process,
            DateCreated = dtNow
        }; 
        var wh2courier = new BusinessProcessState
        {
            Name = "Warehouse backend (wh2courier)",
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var courier = new BusinessProcessState
        {
            Name = "Courier backend",
            BusinessProcess = process,
            DateCreated = dtNow
        }; 
        var kitchen = new BusinessProcessState
        {
            Name = "Kitchen backend",
            BusinessProcess = process,
            DateCreated = dtNow
        }; 
        var fileserivce = new BusinessProcessState
        {
            Name = "File service",
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var states = new List<BusinessProcessState>
        {
            customer,
            wh2kitchen,
            wh2courier,
            courier,
            kitchen,
            fileserivce
        };

        // Transitions.
        var transitions = new List<BusinessProcessStateTransition>
        {
            new BusinessProcessStateTransition
            {
                BusinessProcess = process,
                FromState = customer,
                ToState = wh2kitchen,
                DateCreated = dtNow
            },
            new BusinessProcessStateTransition
            {
                BusinessProcess = process,
                FromState = wh2kitchen,
                ToState = kitchen,
                DateCreated = dtNow
            },
            new BusinessProcessStateTransition
            {
                BusinessProcess = process,
                FromState = kitchen,
                ToState = wh2courier,
                DateCreated = dtNow
            },
            new BusinessProcessStateTransition
            {
                BusinessProcess = process,
                FromState = wh2courier,
                ToState = courier,
                DateCreated = dtNow
            }
        };

        context.BusinessProcesses.Add(process);
        context.BusinessProcessStates.AddRange(states);
        context.BusinessProcessStateTransitions.AddRange(transitions);

        context.SaveChanges();
    }
}
