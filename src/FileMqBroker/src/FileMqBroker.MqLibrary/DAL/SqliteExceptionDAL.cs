using System.Data;
using System.Data.SQLite;
using System.Text;
using Dapper;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.DAL;

/// <summary>
/// Allows you to add information about exceptions to the database.
/// </summary>
public class SqliteExceptionDAL : IExceptionDAL
{
    private readonly string m_connectionString;
    private readonly string m_insertSQL = "INSERT INTO ExceptionLog (ExceptionMessage) VALUES ";

    /// <summary>
    /// Default constructor.
    /// </summary>
    public SqliteExceptionDAL(AppInitConfigs appInitConfigs)
    {
        m_connectionString = appInitConfigs.DbConnectionString;
    }

    /// <summary>
    /// Method for inserting the specified exceptions into DB.
    /// </summary>
    public void InsertExceptions(IReadOnlyList<string> exceptions)
    {
        if (exceptions == null)
            throw new System.ArgumentNullException(nameof(exceptions));
        if (exceptions.Count == 0)
            return;
        
        var sqlQuery = GenerateInsertSqlByExceptions(exceptions);

        using (var connection = new SQLiteConnection(m_connectionString))
        {
            connection.Execute(sqlQuery.Query, sqlQuery.Parameters);
        }
    }

    /// <summary>
    /// Method for generating an SQL query for inserting data about exceptions.
    /// </summary>
    private (string Query, DynamicParameters Parameters) GenerateInsertSqlByExceptions(IReadOnlyList<string> exceptions)
    {
        if (exceptions == null)
            throw new System.ArgumentNullException(nameof(exceptions));
        
        var queryParameters = new DynamicParameters();
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(m_insertSQL);

        for (int i = 0; i < exceptions.Count; i++)
        {
            if (i > 0)
                stringBuilder.Append(", ");
            stringBuilder.Append($"(@ExceptionMessage{i})");
            
            queryParameters.Add($"ExceptionMessage{i}", exceptions[i]);
        }

        return (stringBuilder.ToString(), queryParameters);
    }
}