using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.BL.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.BL.DAL;

/// <summary>
/// A class at the DAL level that performs logging-related operations in the database.
/// </summary>
public class LoggingDAL : ILoggingDAL
{
    private DbContextOptions<ServiceInteractionContext> m_contextOptions;

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public LoggingDAL(
        DbContextOptions<ServiceInteractionContext> contextOptions) 
    {
        m_contextOptions = contextOptions;
    }

    /// <summary>
    /// A method that adds logs to the database.
    /// </summary>
    public void AddDbgLog(string sourceName, string sourceDetails)
    {
        using var context = new ServiceInteractionContext(m_contextOptions);
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