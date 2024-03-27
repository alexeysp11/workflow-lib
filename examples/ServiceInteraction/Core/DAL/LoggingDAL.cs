using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.DAL;

/// <summary>
/// 
/// </summary>
public class LoggingDAL
{
    private DbContextOptions<ServiceInteractionContext> m_contextOptions { get; set; }

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