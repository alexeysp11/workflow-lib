using System.Data; 
using Npgsql;
using Cims.WorkflowLib.Models.Database;

namespace Cims.WorkflowLib.DbConnections
{
    /// <summary>
    /// PostgreSQL database connection.
    /// </summary>
    public class PgDbConnection : BaseDbConnection, ICommonDbConnection
    {
        private string DataSource { get; set; }
        private string ConnString { get; set; }

        public PgDbConnection() { }

        public PgDbConnection(string dataSource)
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
            using (var conn = new NpgsqlConnection(string.IsNullOrEmpty(DataSource) ? ConnString : DataSource))
            {
                conn.Open();
                using (var command = new NpgsqlCommand(sqlRequest, conn))
                {
                    var reader = command.ExecuteReader();
                    table = GetDataTable(reader); 
                    reader.Close();
                    result.DataTableResult = table;
                }
            }
            return result; 
        }

        public new string GetSqlFromDataTable(DataTable dt, string tableName)
        {
            return base.GetSqlFromDataTable(dt, tableName); 
        }

        private DataTable GetDataTable(NpgsqlDataReader reader)
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
