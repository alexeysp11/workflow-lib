using System.Data;

var table = CreateTable("ParentTable");
CreateColumn(table, "Id", System.Type.GetType("System.Int32"), unique: true);

for (int i = 0; i <= 2; i++)
{
    var row = table.NewRow();
    row["Id"] = i;
    AddRow(table, row);
}

Console.WriteLine("Values:");
foreach (DataRow row in table.Rows)
{
    var rowValue = row["Id"].ToString();
    Console.WriteLine($"- {rowValue}");;
}

DataTable CreateTable(string name)
{
    return new DataTable(name);
}

void CreateColumn(
    DataTable table,
    string name,
    Type type,
    int? maxLength = null,
    string? caption = null,
    bool readOnly = false,
    bool unique = false,
    bool autoIncrement = false)
{
    var column = new DataColumn();

    column.ColumnName = name;
    column.DataType = type;
    column.ReadOnly = readOnly;
    column.Unique = unique;

    table.Columns.Add(column);
}

void AddRow(DataTable table, DataRow row)
{
    table.Rows.Add(row);
}
