# UserExistance Class 

Namespace: [WokflowLib.Authentication.Models.NetworkParameters](WokflowLib.Authentication.Models.NetworkParameters.md)

Esistance of the specified user.

## Constructors

### UserExistance()

Default constructor.

```C#
public UserExistance();
```

## Properties

### LoginExists

Shows if the specified login exists in the database.

```C#
public bool LoginExists { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the specified login exists in the database.

### EmailExists

Shows if the specified email exists in the database.

```C#
public bool EmailExists { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the specified email exists in the database.

### PhoneNumberExists

Shows if the specified phone number exists in the database.

```C#
public bool PhoneNumberExists { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the specified phone number exists in the database.

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
