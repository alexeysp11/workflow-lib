using System.Collections.Concurrent;

namespace WorkflowLib.DataStorage.Core.Tables;

/// <summary>
/// 
/// </summary>
public class InMemoryRecord<T> where T : IComparable<T>
{
    private ConcurrentDictionary<InMemoryColumn<T>, InMemoryCell<T>> _values;
    private IReadOnlyDictionary<InMemoryColumn<T>, InMemoryCell<T>> _cachedValues;

    public IReadOnlyDictionary<InMemoryColumn<T>, InMemoryCell<T>> Values
    {
        get
        {
            if (_cachedValues == null)
            {
                _cachedValues = new Dictionary<InMemoryColumn<T>, InMemoryCell<T>>();
            }
            return _cachedValues;
        }
    }
}