namespace WorkflowLib.DataStorage.Core.Tables;

/// <summary>
/// 
/// </summary>
public class InMemoryTable
{
    private List<InMemoryColumn<IComparable<object>>> _columns;
    private IReadOnlyList<InMemoryRecord<IComparable<object>>> _records;
    private IReadOnlyList<InMemoryColumn<IComparable<object>>> _cachedColumns;
    private IReadOnlyList<InMemoryRecord<IComparable<object>>> _cachedRecords;
    
    public IReadOnlyList<InMemoryColumn<IComparable<object>>> InMemoryColumns
    {
        get
        {
            if (_cachedColumns == null)
            {
                _cachedColumns = new List<InMemoryColumn<IComparable<object>>>(_columns);
            }
            return _cachedColumns;
        }
    }
    
    public IReadOnlyList<InMemoryRecord<IComparable<object>>> InMemoryRecords
    {
        get
        {
            if (_cachedRecords == null)
            {
                _cachedRecords = new List<InMemoryRecord<IComparable<object>>>(_records);
            }
            return _cachedRecords;
        }
    }

    public InMemoryTable()
    {
        _columns = new List<InMemoryColumn<IComparable<object>>>();
    }

    public void AddColumn(InMemoryColumn<IComparable<object>> column)
    {
        _columns.Add(column);
    }

    private void ClearCache()
    {
        _cachedColumns = null;
    }
}