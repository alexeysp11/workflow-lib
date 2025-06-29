using System.Data;

namespace WorkflowLib.InMemoryDb.Core.DataStorage.Databases;

public class RelationalDatabase
{
    private string _name;
    private Dictionary<string, DataTable> _tables;

    public string Name => _name;

    public RelationalDatabase() : this("")
    {
    }

    public RelationalDatabase(string name)
    {
        _name = name;
        _tables = new Dictionary<string, DataTable>();
    }

    public DataSet CreateSchema(string name)
    {
        return new DataSet(name);
    }

    public DataTable CreateTable(string name)
    {
        if (_tables.ContainsKey(name))
        {
            return _tables[name];
        }
        var table = new DataTable(name);
        _tables.Add(name, table);
        return table;
    }

    public void CreateColumn(
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

    public void AddRow(DataTable table, DataRow row)
    {
        table.Rows.Add(row);
    }

    public DataTable? GetTable(string name)
    {
        if (_tables.ContainsKey(name))
        {
            return _tables[name];
        }
        return null;
    }
}