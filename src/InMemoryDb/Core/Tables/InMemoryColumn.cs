namespace WorkflowLib.InMemoryDb.Core.Tables;

/// <summary>
/// 
/// </summary>
public class InMemoryColumn<T> where T : IComparable<T>
{
    private List<T> _cells;
    private IReadOnlyList<T> _cachedCells;

    public string Name { get; set; }
    public InMemoryTable InMemoryTable { get; set; }
    public IReadOnlyList<T> InMemoryCells
    {
        get
        {
            if (_cachedCells == null)
            {
                _cachedCells = new List<T>(_cells);
            }
            return _cachedCells;
        }
    }

    // Additional properties like data type, constraints, etc. can be added here.

    public InMemoryColumn(string name, InMemoryTable inMemoryTable)
    {
        Name = name;
        InMemoryTable = inMemoryTable;

        _cells = new List<T>();
    }

    private void ClearCache()
    {
        _cachedCells = null;
    }
}