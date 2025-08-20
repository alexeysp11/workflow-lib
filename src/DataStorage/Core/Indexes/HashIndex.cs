namespace WorkflowLib.DataStorage.Core.Indexes;

/// <summary>
/// The HashIndex class, which implements a hash index.
/// </summary>
public class HashIndex<TKey, TValue>
{
    private Dictionary<TKey, TValue> _index;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public HashIndex()
    {
        _index = new Dictionary<TKey, TValue>();
    }

    /// <summary>
    /// Add an element to the index.
    /// </summary>
    public void AddElement(TKey key, TValue value)
    {
        if (!_index.ContainsKey(key))
        {
            _index.Add(key, value);
        }
        else
        {
            _index[key] = value;
        }
    }

    /// <summary>
    /// Remove an element from the index.
    /// </summary>
    public bool RemoveElement(TKey key)
    {
        if (_index.ContainsKey(key))
        {
            _index.Remove(key);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Search for an element in the index.
    /// </summary>
    public TValue? SearchElement(TKey key)
    {
        if (_index.ContainsKey(key))
        {
            return _index[key];
        }
        return default(TValue);
    }
}
