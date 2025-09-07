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
    /// Whether the value is incremented.
    /// </summary>
    public bool Incremented { get; }

    /// <summary>
    /// Whether the incrementing operation is successful.
    /// </summary>
    public bool Success => Value != null;

    public HashTableIncrementResult(int? value, bool isNew, bool incremented)
    {
        Value = value;
        IsNew = isNew;
        Incremented = incremented;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, IsNew, Incremented);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is HashTableIncrementResult))
        {
            return false;
        }
        HashTableIncrementResult other = (HashTableIncrementResult)obj;
        return Value == other.Value
            && IsNew == other.IsNew
            && Incremented == other.Incremented;
    }

    public override string ToString()
    {
        return $"Value: '{Value}', IsNew: {IsNew}, Incremented: {Incremented}";
    }

    public static bool operator ==(HashTableIncrementResult left, HashTableIncrementResult right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(HashTableIncrementResult left, HashTableIncrementResult right)
    {
        return !(left == right);
    }
}
