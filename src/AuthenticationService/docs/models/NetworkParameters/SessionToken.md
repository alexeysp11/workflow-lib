# SessionToken Class 

Namespace: [WokflowLib.Authentication.Models.NetworkParameters](WokflowLib.Authentication.Models.NetworkParameters.md)

Session token.

## Constructors

### SessionToken()

Default constructor.

```C#
public SessionToken();
```

## Properties 

### TokenGuid

Token GUID.

```C#
public string? TokenGuid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Token GUID.

### TokenBeginDt

Token begin timestamp.

```C#
public System.DateTime TokenBeginDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Token begin timestamp.

### TokenEndDt

Token end timestamp.

```C#
public System.DateTime TokenEndDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Token end timestamp.

### UserType

User type.

```C#
public string? UserType { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

User type.

### ExceptionMessage

Exception message.

```C#
public string? ExceptionMessage { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Exception message.

### WorkflowException

Workflow exception.

```C#
public WorkflowException? WorkflowException { get; set; }
```

#### Property Value

[WorkflowException](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/ErrorHandling/WorkflowException.cs)

Workflow exception.
