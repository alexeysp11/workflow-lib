using System.Data; 
using Microsoft.Data.Sqlite;
using WorkflowLib.Models.Database;

namespace WorkflowLib.DbConnections
{
    /// <summary>
    /// Class for using SQLite database
    /// </summary>
    public class SqliteDbConnection : BaseDbConnection, ICommonDbConnection 
    {
        private string ConnString { get; set; }
        private string AbsolutePathToDb { get; set; }

        public SqliteDbConnection() 
            : this(string.Empty)
        {
        }
        
        public SqliteDbConnection(string path)
        {
            try
            {
                SetPathToDb(path); 
            }
            catch (System.Exception)
            {
                throw; 
            }
        }

        public ICommonDbConnection SetConnString(string connString)
        {
            ConnString = connString; 
            return this; 
        }

        public void SetPathToDb(string path)
        {
            if (!System.IO.File.Exists(path)) throw new System.Exception($"Database file '{path}' does not exists");
            
            this.AbsolutePathToDb = path; 
        }

        /// <summary>
        /// Executes SQL string and returns DataTable
        /// </summary>
        public SqlResultWF ExecuteSqlCommand(string sqlRequest)
        {
            SqlResultWF result = new SqlResultWF();
            DataTable table = new DataTable(); 
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = AbsolutePathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = sqlRequest; 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        table.Load(reader);
                        result.DataTableResult = table;
                    }
                }
                catch (System.Exception)
                {
                    throw; 
                }
            }
            return result; 
        }

        public new string GetSqlFromDataTable(DataTable dt, string tableName)
        {
            return base.GetSqlFromDataTable(dt, tableName); 
        }
    }
}
