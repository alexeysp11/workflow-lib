# VUCResponse Class 

Namespace: [WokflowLib.Authentication.Models.NetworkParameters](WokflowLib.Authentication.Models.NetworkParameters.md)

The result of verification of user credintials.

## Constructors

### VUCResponse()

Default constructor.

```C#
public VUCResponse();
```

## Properties

### IsVerified

Shows if the user credentials are verified.

```C#
public bool IsVerified { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the user credentials are verified.

### UserUid

User GUID.

```C#
public string? UserUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

User GUID.

### UserCredentials

User creadentials.

```C#
public UserCredentials? UserCredentials { get; set; }
```

#### Property Value

[UserCredentials](UserCredentials.md)

User creadentials.

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
