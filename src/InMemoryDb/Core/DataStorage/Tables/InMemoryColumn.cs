using System;
using System.Collections.Generic;

namespace WorkflowLib.InMemoryDb.Core.DataStorage.Tables;

/// <summary>
/// 
/// </summary>
public class InMemoryColumn<T> where T : IComparable<T>
{
    private List<T> m_cells;
    private IReadOnlyList<T> m_cachedCells;

    public string Name { get; set; }
    public InMemoryTable InMemoryTable { get; set; }
    public IReadOnlyList<T> InMemoryCells
    {
        get
        {
            if (m_cachedCells == null)
            {
                m_cachedCells = new List<T>(m_cells);
            }
            return m_cachedCells;
        }
    }

    // Additional properties like data type, constraints, etc. can be added here.

    public InMemoryColumn(string name, InMemoryTable inMemoryTable)
    {
        Name = name;
        InMemoryTable = inMemoryTable;

        m_cells = new List<T>();
    }

    private void ClearCache()
    {
        m_cachedCells = null;
    }
}