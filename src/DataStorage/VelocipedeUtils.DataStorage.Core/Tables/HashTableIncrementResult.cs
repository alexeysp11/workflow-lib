namespace VelocipedeUtils.DataStorage.Core.Tables;

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
    /// Whether the incrementing operation is successful.
    /// </summary>
    public bool Success => Value.HasValue;

    public HashTableIncrementResult(int? value)
    {
        Value = value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Success);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is HashTableIncrementResult))
        {
            return false;
        }
        HashTableIncrementResult other = (HashTableIncrementResult)obj;
        return Value == other.Value
            && Success == other.Success;
    }

    public override string ToString()
    {
        return $"Value: '{Value}', Success: {Success}";
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
