using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.DAL;
using VelocipedeUtils.Shared.Models.Logging;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DAL;

/// <summary>
/// A class at the DAL level that performs logging-related operations in the database.
/// </summary>
public class LoggingDAL : ILoggingDAL
{
    private object m_object = new object();
    private DbContextOptions<ServiceInteractionDbContext> m_contextOptions;

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public LoggingDAL(
        DbContextOptions<ServiceInteractionDbContext> contextOptions) 
    {
        m_contextOptions = contextOptions;
    }

    /// <summary>
    /// A method that adds logs to the database.
    /// </summary>
    public void AddDbgLog(string sourceName, string sourceDetails)
    {
        var dbglog = new DbgLog
        {
            SourceName = sourceName,
            SourceDetails = sourceDetails,
            DateCreated = System.DateTime.UtcNow,
            DateChanged = System.DateTime.UtcNow
        };

        lock (m_object)
        {
            using var context = new ServiceInteractionDbContext(m_contextOptions);
            context.DbgLogs.Add(dbglog);
            context.SaveChanges();
        }
    }
}