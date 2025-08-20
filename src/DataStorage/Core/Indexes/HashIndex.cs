using WorkflowLib.DataStorage.Core.Tables;

namespace WorkflowLib.DataStorage.Core.Indexes;

/// <summary>
/// The HashIndex class, which implements a hash index.
/// </summary>
public class HashIndex<TKey, TValue> : InMemoryHashTable<TKey, TValue>
{
}
