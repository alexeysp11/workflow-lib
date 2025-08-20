using System.Collections.Generic;

namespace WorkflowLib.InMemoryDb.Core.DataStorage.Indexes;

/// <summary>
/// The HashIndex class, which implements a hash index.
/// </summary>
public class HashIndex<TKey, TValue>
{
    private Dictionary<TKey, TValue> m_index;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public HashIndex()
    {
        m_index = new Dictionary<TKey, TValue>();
    }

    /// <summary>
    /// Add an element to the index.
    /// </summary>
    public void AddElement(TKey key, TValue value)
    {
        if (!m_index.ContainsKey(key))
        {
            m_index.Add(key, value);
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
        if (m_index.ContainsKey(key))
        {
            m_index.Remove(key);
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
        if (m_index.ContainsKey(key))
        {
            return m_index[key];
        }
        else
        {
            // Handle key not found scenario if needed.
            throw new System.InvalidOperationException("Key not found in the index.");
            return default(TValue);
        }
    }
}
