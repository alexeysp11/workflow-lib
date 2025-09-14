namespace VelocipedeUtils.Shared.ServiceDiscoveryBpm.DAL;

/// <summary>
/// An interface at the DAL level that performs logging-related operations in the database.
/// </summary>
public interface ILoggingDAL
{
    /// <summary>
    /// A method that adds logs to the database.
    /// </summary>
    void AddDbgLog(string sourceName, string sourceDetails);
}