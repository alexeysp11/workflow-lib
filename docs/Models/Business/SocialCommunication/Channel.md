# Channel Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.SocialCommunication](Cims.WorkflowLib.Models.Business.SocialCommunication.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

Channel in a chat app.

## Constructors

### Channel()

Default constructor.

```C#
public Channel();
```

## Properties 

### Id

ID of a channel.

```C#
public long Id { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

ID of a channel.

### Uid

UID of a channel.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of a channel.

### Description

Description of a message.

```C#
public string Description { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Description of a message.

### Title

Title of a message.

```C#
public string Title { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Title of a message.

### DateCreated

Timestamp when a message was created.

```C#
public DateTime DateCreated { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Timestamp when a message was created.
