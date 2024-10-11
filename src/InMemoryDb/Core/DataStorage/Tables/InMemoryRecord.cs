using System.Collections.Concurrent;
using System.Collections.Generic;

namespace WorkflowLib.InMemoryDb.Core.DataStorage.Tables;

/// <summary>
/// 
/// </summary>
public class InMemoryRecord<T> where T : IComparable<T>
{
    private ConcurrentDictionary<InMemoryColumn<T>, InMemoryCell<T>> m_values;
    private IReadOnlyDictionary<InMemoryColumn<T>, InMemoryCell<T>> m_cachedValues;

    public IReadOnlyDictionary<InMemoryColumn<T>, InMemoryCell<T>> Values
    {
        get
        {
            if (m_cachedValues == null)
            {
                m_cachedValues = new Dictionary<InMemoryColumn<T>, InMemoryCell<T>>();
            }
            return m_cachedValues;
        }
    }
}