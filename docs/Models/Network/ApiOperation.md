# ApiOperation Class

*Namespace*: [Cims.WorkflowLib.Models.Network](Cims.WorkflowLib.Models.Network.md)

Represents any attempt to communcate with API server as an operation.

## Constructors

### ApiOperation()

Default constructor.

```C#
public ApiOperation();
```

## Properties

### ClientAppUid

Client application UID.

```C#
public string ClientAppUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### ServerAppUid

Server application UID.

```C#
public string ServerAppUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### MethodName

Name of the method that should be executed to perform the operation.

```C#
public string MethodName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### MethodDescription

Description of the method that should be executed to perform the operation (contextual name of the operation, e.g. "adding two values").

```C#
public string MethodDescription { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Request

String representation of JSON object that is sent as a request to the server.

```C#
public string Request { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Response

String representation of JSON object that is received as a response from the server.

```C#
public string Response { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### IsExecuted

Boolean variable that is set by a server to indicate if the request is executed properly.

```C#
public bool IsExecuted { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

### Status

String representation of the status of the operation (e.g. executed, failed, pending).

```C#
public string Status { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### StatusDescription

Additional information about the status of the operation.

```C#
public string StatusDescription { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### ExecutionTime

Property that could be used to measure performance of the API operation (execution time).

```C#
public ExecutionTime ExecutionTime { get; set; }
```

#### Property Value

[ExecutionTime](../Performance/ExecutionTime.md)

### WorkflowException

Exception that is occurred during execution of the API operation.

```C#
public WorkflowException WorkflowException { get; set; }
```

#### Property Value

[WorkflowException](../ErrorHandling/WorkflowException.md)
