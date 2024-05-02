# CheckUCConfig Class 

Namespace: [WokflowLib.Authentication.Models.ConfigParameters](WokflowLib.Authentication.Models.ConfigParameters.md)

Config properties that is used for checking if the user credentials were filled properly.

## Constructors 

### CheckUCConfig()

Default constructor.

```C#
public CheckUCConfig();
```

## Properties

### IsLoginRequired

Shows if it is necessary to check the user login.

```C#
public bool IsLoginRequired { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if it is necessary to check the user login.

### IsEmailRequired

Shows if it is necessary to check the user email.

```C#
public bool IsEmailRequired { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if it is necessary to check the user email.

### IsPhoneNumberRequired

Shows if it is necessary to check the user phone number.

```C#
public bool IsPhoneNumberRequired { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if it is necessary to check the user phone number.

### IsPasswordRequired

Shows if it is necessary to check the user password.

```C#
public bool IsPasswordRequired { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Shows if it is necessary to check the user password.
