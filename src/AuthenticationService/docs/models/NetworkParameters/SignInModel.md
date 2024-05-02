# SignInModel Class 

Namespace: [WokflowLib.Authentication.Models.NetworkParameters](WokflowLib.Authentication.Models.NetworkParameters.md)

Sign in model.

## Constructors 

### SignInModel()

Default constructor.

```C#
public SignInModel();
```

## Properties 

### Login

User login.

```C#
public string? Login { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

User login.

### Password

User password.

```C#
public string? Password { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

User password.

### KeepLoggedIn

Shows if the site needs to send a cookie that enables a persistent session.

```C#
public bool KeepLoggedIn { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if the site needs to send a cookie that enables a persistent session.
