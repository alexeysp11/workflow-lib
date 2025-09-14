using System.Data;
using Npgsql;

namespace VelocipedeUtils.Examples.PublicTransportDevices.DbConnections
{
    public class PgDbConnection : ICommonDbConnection
    {
        private string DataSource { get; set; }

        public PgDbConnection(string dataSource)
        {
            DataSource = dataSource;
        }

        public DataTable ExecuteSqlCommand(string sqlRequest)
        {
            DataTable table = new DataTable();
            using (var conn = new NpgsqlConnection(DataSource))
            {
                conn.Open();
                using (var command = new NpgsqlCommand(sqlRequest, conn))
                {
                    var reader = command.ExecuteReader();
                    table = GetDataTable(reader);
                    reader.Close();
                }
            }
            return table;
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