# VSUResponse Class 

Namespace: [WokflowLib.Authentication.Models.NetworkParameters](WokflowLib.Authentication.Models.NetworkParameters.md)

The response to confirmation of registration using the verification code.

## Constructors

### VSUResponse()

Default constructor.

```C#
public VSUResponse();
```

## Properties

### IsSuccessful

Shows if the verification of the sign up was successful.

```C#
public bool IsSuccessful { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the verification of the sign up was successful.

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
