using System.Data;

var table = new DataTable("ParentTable");

var column = new DataColumn();
column.DataType = System.Type.GetType("System.Int32");
column.ColumnName = "Id";
column.ReadOnly = false;
column.Unique = true;

table.Columns.Add(column);

for (int i = 0; i <= 2; i++)
{
    var row = table.NewRow();
    row["Id"] = i;
    table.Rows.Add(row);
}

Console.WriteLine("Values:");
foreach (DataRow row in table.Rows)
{
    var rowValue = row["Id"].ToString();
    Console.WriteLine($"- {rowValue}");;
}
