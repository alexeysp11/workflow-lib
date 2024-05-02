# VSURequest Class 

Namespace: [WokflowLib.Authentication.Models.NetworkParameters](WokflowLib.Authentication.Models.NetworkParameters.md)

The request to confirm sign up using a verification code.

## Constructors

### VSURequest()

Default constructor.

```C#
public VSURequest();
```

## Properties

### SignUpGuid

Requested sign up UID.

```C#
public string? SignUpGuid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Requested sign up UID.

### TriesNumber

Number of tries that a user made to enter verification code during the sign up process.

```C#
public int TriesNumber { get; set; }
```

#### Property Value

[Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)

Number of tries that a user made to enter verification code during the sign up process.

### IsDeprecated

Shows if the specified sign up UID is deprecated.

```C#
public bool IsDeprecated { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the specified sign up UID is deprecated.

### IsOverriden

Shows if the specified sign up UID is overriden.

```C#
public bool IsOverriden { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the specified sign up UID is overriden.

### SignUpClosingCode

Sign up closing code.

```C#
public string? SignUpClosingCode { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Sign up closing code.
