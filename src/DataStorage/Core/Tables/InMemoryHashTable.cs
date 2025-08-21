namespace WorkflowLib.DataStorage.Core.Tables;

/// <summary>
/// Implements a thread-safe in-memory hash table.
/// </summary>
public class InMemoryHashTable<TKey, TValue>
{
    private object _obj = new object();
    private Dictionary<TKey, TValue> _records;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public InMemoryHashTable()
    {
        _records = new Dictionary<TKey, TValue>();
    }

    /// <summary>
    /// Add an element to the hash table.
    /// </summary>
    public void AddElement(TKey key, TValue value)
    {
        lock (_obj)
        {
            if (!_records.ContainsKey(key))
            {
                _records.Add(key, value);
            }
            else
            {
                _records[key] = value;
            }
        }
    }

    /// <summary>
    /// Remove an element from the hash table.
    /// </summary>
    public bool RemoveElement(TKey key)
    {
        lock (_obj)
        {
            if (_records.ContainsKey(key))
            {
                _records.Remove(key);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Search for an element in the hash table.
    /// </summary>
    public TValue? SearchElement(TKey key)
    {
        lock (_obj)
        {
            if (_records.ContainsKey(key))
            {
                return _records[key];
            }
        }
        return default(TValue);
    }
}
