using VelocipedeUtils.DataStorage.Core.Tables;

namespace VelocipedeUtils.DataStorage.Core.Indexes;

/// <summary>
/// Implements a hash index.
/// </summary>
public class HashIndex<TKey, TValue> : InMemoryHashTable<TKey, TValue> where TKey : notnull
{
}
