# IBusinessEntityWF Interface 

*Namespace*: [Cims.WorkflowLib.Models.Business](Cims.WorkflowLib.Models.Business.md)

Interface that represents a business entity.

## Properties

### Id

ID of the business entity.

```C#
public long Id { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

### Uid

UID of the business entity.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Name

Name of the business entity.

```C#
public string Name { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Description

Description of the business entity.

```C#
public string Description { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### BusinessEntityStatus

Status of the business entity.

```C#
public BusinessEntityStatus BusinessEntityStatus { get; set; }
```

#### Property Value

[BusinessEntityStatus](BusinessEntityStatus.md)
