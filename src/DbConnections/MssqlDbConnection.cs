using System.Data; 
using Microsoft.Data.SqlClient;

namespace Cims.WorkflowLib.DbConnections
{
    public class MssqlDbConnection : BaseDbConnection, ICommonDbConnection
    {
        private string DataSource { get; set; }
        private string ConnString { get; set; }

        public MssqlDbConnection() { }

        public MssqlDbConnection(string dataSource)
        {
            DataSource = dataSource; 
        }

        public ICommonDbConnection SetConnString(string connString)
        {
            ConnString = connString; 
            return this; 
        }

        public DataTable ExecuteSqlCommand(string sqlRequest)
        {
            DataTable table = new DataTable(); 
            try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                // builder.DataSource = "<your_server.database.windows.net>"; 
                // builder.UserID = "<your_username>";            
                // builder.Password = "<your_password>";     
                // builder.InitialCatalog = "<your_database>";

                builder.ConnectionString = string.IsNullOrEmpty(DataSource) ? ConnString : DataSource;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlRequest, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            table = reader.GetSchemaTable();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return table; 
        }

        public new string GetSqlFromDataTable(DataTable dt, string tableName)
        {
            return base.GetSqlFromDataTable(dt, tableName); 
        }
    }
}
