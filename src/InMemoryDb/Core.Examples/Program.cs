using System.Data;
using WorkflowLib.InMemoryDb.Core.DataStorage.Databases;

// Initialize.
var db = new RelationalDatabase("TestDatabase");
var table = db.CreateTable("ParentTable");
db.CreateColumn(table, "Id", typeof(int), unique: true);

// Add data.
for (int i = 0; i <= 2; i++)
{
    var row = table.NewRow();
    row["Id"] = i;
    db.AddRow(table, row);
}

// Print data.
Console.WriteLine("Values:");
foreach (DataRow row in table.Rows)
{
    var rowValue = row["Id"].ToString();
    Console.WriteLine($"- {rowValue}");;
}
