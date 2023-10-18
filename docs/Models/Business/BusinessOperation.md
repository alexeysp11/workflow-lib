# BusinessOperation Class

*Namespace*: [Cims.WorkflowLib.Models.Business](Cims.WorkflowLib.Models.Business.md)

*Implements*: [IBusinessEntityWF](IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](BusinessEntityWF.md)

Representation of a business operation.

## Constructors

### BusinessOperation()

Default constructor.

```C#
public BusinessOperation();
```

## Properties

### ActualExecutionTime

Actual execution time of the business operation.

```C#
public ExecutionTime ActualExecutionTime { get; set; }
```

#### Property Value

[ExecutionTime](../Performance/ExecutionTime.md)

### EstimatedExecutionTime

Estimated execution time of the business operation.

```C#
public ExecutionTime EstimatedExecutionTime { get; set; }
```

#### Property Value

[ExecutionTime](../Performance/ExecutionTime.md)

### Status

Status of the business operation.

```C#
public string Status { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)
