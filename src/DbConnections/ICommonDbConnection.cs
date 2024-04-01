using System.Data;
using WorkflowLib.Models.Database;

namespace WorkflowLib.DbConnections
{
    /// <summary>
    /// Interface for database connections.
    /// </summary>
    public interface ICommonDbConnection
    {
        /// <summary>
        /// Execute SQL command.
        /// </summary>
        SqlResultWF ExecuteSqlCommand(string sqlRequest); 
        
        /// <summary>
        /// Gets SQL definition of the DataTable object.
        /// </summary>
        string GetSqlFromDataTable(DataTable dt, string tableName); 

        /// <summary>
        /// Sets connection string.
        /// </summary>
        ICommonDbConnection SetConnString(string connString);
    }
}
