using System.Collections.Generic;

namespace WorkflowLib.InMemoryDb.Core.DataStorage.Tables;

/// <summary>
/// 
/// </summary>
public class InMemoryTable
{
    private List<InMemoryColumn<IComparable<object>>> m_columns;
    private IReadOnlyList<InMemoryRecord<IComparable<object>>> m_records;
    private IReadOnlyList<InMemoryColumn<IComparable<object>>> m_cachedColumns;
    private IReadOnlyList<InMemoryRecord<IComparable<object>>> m_cachedRecords;
    
    public IReadOnlyList<InMemoryColumn<IComparable<object>>> InMemoryColumns
    {
        get
        {
            if (m_cachedColumns == null)
            {
                m_cachedColumns = new List<InMemoryColumn<IComparable<object>>>(m_columns);
            }
            return m_cachedColumns;
        }
    }
    
    public IReadOnlyList<InMemoryRecord<IComparable<object>>> InMemoryRecords
    {
        get
        {
            if (m_cachedRecords == null)
            {
                m_cachedRecords = new List<InMemoryRecord<IComparable<object>>>(m_records);
            }
            return m_cachedRecords;
        }
    }

    public InMemoryTable()
    {
        m_columns = new List<InMemoryColumn<IComparable<object>>>();
    }

    public void AddColumn(InMemoryColumn<IComparable<object>> column)
    {
        m_columns.Add(column);
    }

    private void ClearCache()
    {
        m_cachedColumns = null;
    }
}