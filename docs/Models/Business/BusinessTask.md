# BusinessTask Class

*Namespace*: [Cims.WorkflowLib.Models.Business](Cims.WorkflowLib.Models.Business.md)

*Implements*: [IBusinessEntityWF](IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](BusinessEntityWF.md)

Representation of a business task.

## Constructors

### BusinessTask()

Default constructor.

```C#
public BusinessTask();
```

## Properties

### ActualExecutionTime

Actual execution time of the business task.

```C#
public ExecutionTime ActualExecutionTime { get; set; }
```

#### Property Value

[ExecutionTime](../Performance/ExecutionTime.md)

### EstimatedExecutionTime

Estimated execution time of the business task.

```C#
public ExecutionTime EstimatedExecutionTime { get; set; }
```

#### Property Value

[ExecutionTime](../Performance/ExecutionTime.md)

### Status

Status of the business task.

```C#
public string Status { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)