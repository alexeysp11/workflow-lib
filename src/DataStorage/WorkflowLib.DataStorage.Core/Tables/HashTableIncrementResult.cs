namespace WorkflowLib.DataStorage.Core.Tables;

/// <summary>
/// Result of the increment operation in the hash table.
/// </summary>
public readonly struct HashTableIncrementResult
{
    /// <summary>
    /// Value after incrementing the value.
    /// </summary>
    public int? Value { get; }

    /// <summary>
    /// Whether the value is new.
    /// </summary>
    public bool IsNew { get; }

    /// <summary>
    /// Whether the value could be incremented.
    /// </summary>
    public bool Incremented { get; }

    public HashTableIncrementResult(int? value, bool isNew, bool incremented)
    {
        Value = value;
        IsNew = isNew;
        Incremented = incremented;
    }

    public override string ToString()
    {
        return $"Value: {Value}, IsNew: {IsNew}, Incremented: {Incremented}";
    }
}
