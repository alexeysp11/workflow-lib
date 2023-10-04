# ExecutionTime Class

Namespace: [Cims.WorkflowLib.Models.Performance](Cims.WorkflowLib.Models.Performance.md)

Represents the execution time of the operation (could be used for measuring performance).

## Constructors

### ExecutionTime()

Default constructor.

```C#
public ExecutionTime();
```

## Properties

### DateTimeBegin

Timestamp when the operation started.

```C#
public System.DateTime DateTimeBegin { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Timestamp when the operation started.

### DateTimeEnd

Timestamp when the operation ended.

```C#
public System.DateTime DateTimeEnd { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Timestamp when the operation ended.

### TimeDifference

Represents a time interval between the moment when the operation started and the moment when it ended.

```C#
public System.TimeSpan TimeDifference { get; }
```

#### Property Value

[TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan)

Time interval.
