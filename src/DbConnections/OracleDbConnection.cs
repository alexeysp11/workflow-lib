using System.Data; 
using Oracle.ManagedDataAccess.Client;
using WorkflowLib.Models.Database;

namespace WorkflowLib.DbConnections
{
    /// <summary>
    /// Oracle database connection.
    /// </summary>
    public class OracleDbConnection : BaseDbConnection, ICommonDbConnection
    {
        private string DataSource { get; set; }
        private string ConnString { get; set; }
        
        public OracleDbConnection() { }

        public OracleDbConnection(string dataSource)
        {
            DataSource = dataSource; 
        }

        public ICommonDbConnection SetConnString(string connString)
        {
            ConnString = connString; 
            return this; 
        }

        public SqlResultWF ExecuteSqlCommand(string sqlRequest)
        {
            SqlResultWF result = new SqlResultWF();
            DataTable table = new DataTable();
            using (OracleConnection con = new OracleConnection(string.IsNullOrEmpty(DataSource) ? ConnString : DataSource))
            {
                using (OracleCommand cmd = new OracleCommand(sqlRequest, con))
                {
                    con.Open();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        table.Load(dr);
                        result.DataTableResult = table;
                    }
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
