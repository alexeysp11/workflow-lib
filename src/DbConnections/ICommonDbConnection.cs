using System.Data; 

namespace Cims.WorkflowLib.DbConnections
{
    /// <summary>
    /// Interface for database connections.
    /// </summary>
    public interface ICommonDbConnection
    {
        DataTable ExecuteSqlCommand(string sqlRequest); 
        
        string GetSqlFromDataTable(DataTable dt, string tableName); 

        ICommonDbConnection SetConnString(string connString);
    }
}
