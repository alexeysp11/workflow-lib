# BusinessOperation Class

*Namespace*: [Cims.WorkflowLib.Models.Business](Cims.WorkflowLib.Models.Business.md)

Representation of a business operation.

## Constructors

### BusinessOperation()

Default constructor.

```C#
public BusinessOperation();
```

## Properties

### Name

Name of the business operation.

```C#
public string Name { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Name of the business operation.

### Description

Description of the business operation.

```C#
public string Description { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Description of the business operation.

### ActualExecutionTime

Actual execution time of the business operation.

```C#
public ExecutionTime ActualExecutionTime { get; set; }
```

#### Property Value

[ExecutionTime](../Performance/ExecutionTime.md)

Actual execution time of the business operation.

### EstimatedExecutionTime

Estimated execution time of the business operation.

```C#
public ExecutionTime EstimatedExecutionTime { get; set; }
```

#### Property Value

[ExecutionTime](../Performance/ExecutionTime.md)

Estimated execution time of the business operation.

### Status

Status of the business operation.

```C#
public string Status { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Status of the business operation.
