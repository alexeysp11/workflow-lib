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
            // Handle duplicate key scenario if needed.
            throw new System.InvalidOperationException("Key already exists in the index.");
        }
    }

    /// <summary>
    /// Remove an element from the index.
    /// </summary>
    public void RemoveElement(TKey key)
    {
        if (_index.ContainsKey(key))
        {
            _index.Remove(key);
        }
        else
        {
            // Handle key not found scenario if needed.
            throw new System.InvalidOperationException("Key not found in the index.");
        }
    }

    /// <summary>
    /// Search for an element in the index.
    /// </summary>
    public TValue SearchElement(TKey key)
    {
        if (_index.ContainsKey(key))
        {
            return _index[key];
        }
        else
        {
            // Handle key not found scenario if needed.
            throw new System.InvalidOperationException("Key not found in the index.");
            return default(TValue);
        }
    }
}
