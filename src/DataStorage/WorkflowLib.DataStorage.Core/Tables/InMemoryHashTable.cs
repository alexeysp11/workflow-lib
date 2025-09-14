namespace VelocipedeUtils.DataStorage.Core.Tables;

/// <summary>
/// Implements a thread-safe in-memory hash table.
/// </summary>
public class InMemoryHashTable<TKey, TValue> where TKey : notnull
{
    protected object _obj = new object();
    protected Dictionary<TKey, TValue> _records;

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
    public virtual void AddElement(TKey key, TValue value)
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
    public virtual bool RemoveElement(TKey key)
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
    public virtual TValue? SearchElement(TKey key)
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

    /// <summary>
    /// Search for an element in the hash table.
    /// </summary>
    public virtual bool ContainsElement(TKey key)
    {
        lock (_obj)
        {
            return _records.ContainsKey(key);
        }
    }
}
