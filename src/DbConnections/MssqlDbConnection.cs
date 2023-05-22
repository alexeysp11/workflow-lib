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
            SqlConnection connection = null; 
            try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = string.IsNullOrEmpty(DataSource) ? ConnString : DataSource;
                using (connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlRequest, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            table = GetDataTable(reader); 
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
            finally
            {
                if (connection != null) connection.Close();
            }
            return table; 
        }

        public new string GetSqlFromDataTable(DataTable dt, string tableName)
        {
            return base.GetSqlFromDataTable(dt, tableName); 
        }

        private DataTable GetDataTable(SqlDataReader reader)
        {
            DataTable table = new DataTable(); 
            if (reader.FieldCount == 0) return table; 
            for (int i = 0; i < reader.FieldCount; i++)
            {
                DataColumn column; 
                column = new DataColumn();
                column.ColumnName = reader.GetName(i);
                column.ReadOnly = true;
                table.Columns.Add(column);
            }
            while (reader.Read())
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                    row[i] = reader.GetValue(i).ToString();
                table.Rows.Add(row);
            }
            return table; 
        }
    }
}
