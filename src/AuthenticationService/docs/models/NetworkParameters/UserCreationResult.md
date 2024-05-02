# UserCreationResult Class

Namespace: [WokflowLib.Authentication.Models.NetworkParameters](WokflowLib.Authentication.Models.NetworkParameters.md)

The result of adding a user to the database.

## Constructors

### UserCreationResult()

Default constructor.

```C#
public UserCreationResult();
```

## Properties 

### IsUserAdded

Shows if the spicified user was created and added to the database.

```C#
public bool IsUserAdded { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the spicified user was created and added to the database.

### SignUpGuid

Sign up GUID.

```C#
public string? SignUpGuid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Sign up GUID.

### VerificationCode

Verification code.

```C#
public string? VerificationCode { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Verification code.

### CodeSendingDt

Code sending timestamp.

```C#
public System.DateTime CodeSendingDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Code sending timestamp.

### UserExistanceBefore

Shows if the specified user existed in the database before the request.

```C#
public UserExistance? UserExistanceBefore { get; set; }
```

#### Property Value

[UserExistance](UserExistance.md)

Shows if the specified user existed in the database before the request.

### UserExistanceAfter

Shows if the specified user exists in the database after the request.

```C#
public UserExistance? UserExistanceAfter { get; set; }
```

#### Property Value

[UserExistance](UserExistance.md)

Shows if the specified user exists in the database after the request.

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
