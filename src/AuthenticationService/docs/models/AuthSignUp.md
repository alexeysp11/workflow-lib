# AuthSignUp Class 

Namespace: [WokflowLib.Authentication.Models](WokflowLib.Authentication.Models.md)

Sign up.

## Constructors 

### AuthSignUp()

Default constructor.

```C#
public AuthSignUp();
```

## Properties

### Id

ID of the sign up.

```C#
public long Id { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

ID of the sign up.

### Uid

UID of the sign up.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of the sign up.

### UserUid

UID of the user.

```C#
public string UserUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of the user.

### VerificationCode

Verification code for the sign up.

```C#
public string VerificationCode { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Verification code for the sign up.

### VCSendingDt

Verification code sending timestamp.

```C#
public System.DateTime VCSendingDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Verification code sending timestamp.

### TriesNumber

Number of attempts to enter the sign up code.

```C#
public int TriesNumber { get; set; }
```

#### Property Value

[Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)

Number of attempts to enter the sign up code.

### SignUpBeginDt

Sign up begin timestamp.

```C#
public System.DateTime SignUpBeginDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Sign up begin timestamp.

### SignUpEndDt

Sign up end timestamp.

```C#
public System.DateTime SignUpEndDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Sign up end timestamp.

### IsDeprecated

Shows if the sign up attempt is "deprecated".

```C#
public bool IsDeprecated { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the sign up attempt is "deprecated".

### IsOverriden

Shows if the sign up attempt is "overriden".

```C#
public bool IsOverriden { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the sign up attempt is "overriden".

### AuthClosingCode

Authentication closing code.

```C#
public AuthClosingCode AuthClosingCode { get; set; }
```

#### Property Value

[AuthClosingCode](AuthClosingCode.md)

Authentication closing code.
