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
}
