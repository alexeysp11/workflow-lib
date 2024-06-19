using System.Collections.Generic;

namespace WorkflowLib.InMemoryDatabase.DataStorage.Tables;

/// <summary>
/// 
/// </summary>
public class InMemoryCell<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public InMemoryColumn<T> InMemoryColumn { get; private set; }

    // Additional properties like data type, constraints, etc. can be added here.

    public InMemoryCell(T value, InMemoryColumn<T> inMemoryColumn)
    {
        Value = value;
        InMemoryColumn = inMemoryColumn;
    }

    // Additional methods.
}