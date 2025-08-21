using WorkflowLib.DataStorage.Core.Tables;

namespace WorkflowLib.DataStorage.Core.Indexes;

/// <summary>
/// Implements a hash index.
/// </summary>
public class HashIndex<TKey, TValue> : InMemoryHashTable<TKey, TValue>
{
}
