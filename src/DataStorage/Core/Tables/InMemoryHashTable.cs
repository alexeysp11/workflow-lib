namespace WorkflowLib.DataStorage.Core.Tables;

/// <summary>
/// Implements in-memory hash table.
/// </summary>
public class InMemoryHashTable<TKey, TValue>
{
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
        if (!_records.ContainsKey(key))
        {
            _records.Add(key, value);
        }
        else
        {
            _records[key] = value;
        }
    }

    /// <summary>
    /// Remove an element from the hash table.
    /// </summary>
    public bool RemoveElement(TKey key)
    {
        if (_records.ContainsKey(key))
        {
            _records.Remove(key);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Search for an element in the hash table.
    /// </summary>
    public TValue? SearchElement(TKey key)
    {
        if (_records.ContainsKey(key))
        {
            return _records[key];
        }
        return default(TValue);
    }
}
