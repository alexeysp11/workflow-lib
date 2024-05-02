# AuthSignIn Class 

Namespace: [WokflowLib.Authentication.Models](WokflowLib.Authentication.Models.md)

Sign in to the application.

## Constructors 

### AuthSignIn()

Default constructor.

```C#
public AuthSignIn();
```

## Properties

### Id

ID of the sign in.

```C#
public long Id { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

ID of the sign in.

### Uid

UID of the sign in.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of the sign in.

### UserUid

UID of the user.

```C#
public string UserUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of the user.

### SignInBeginDt

Sign in begin timestamp.

```C#
public System.DateTime SignInBeginDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Sign in begin timestamp.

### SignInEndDt

Sign in end timestamp.

```C#
public System.DateTime SignInEndDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Sign in end timestamp.

### IsDeprecated

Shows if the sign in attempt is "deprecated".

```C#
public bool IsDeprecated { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the sign in attempt is "deprecated".

### IsOverriden

Shows if the sign in attempt is "overriden".

```C#
public bool IsOverriden { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the sign in attempt is "overriden".

### AuthClosingCode

Authentication closing code.

```C#
public AuthClosingCode AuthClosingCode { get; set; }
```

#### Property Value

[AuthClosingCode](AuthClosingCode.md)

Authentication closing code.
