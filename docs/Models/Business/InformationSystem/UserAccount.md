# UserAccount Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.InformationSystem](Cims.WorkflowLib.Models.Business.InformationSystem.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

User account.

## Properties 

### Login

Login of the user.

```C#
public string Login { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Email

Email of the user.

```C#
public string Email { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### PhoneNumber

Phone number of the user.

```C#
public string PhoneNumber { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Password

Password of the user.

```C#
public string Password { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Photo

Photo of the user.

```C#
public byte[] Photo { get; set; }
```

#### Property Value

[Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte)[]

### PhotoUrl

Photo URL of the user.

```C#
public string PhotoUrl { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Status

Status of the user.

```C#
public UserStatus Status { get; set; }
```

#### Property Value

[UserStatus](UserStatus.md)

### LastSeenDt

Timestamp when the user was online the last time.

```C#
public System.DateTime LastSeenDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)
