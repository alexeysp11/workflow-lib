# MessageWF Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.SocialCommunication](Cims.WorkflowLib.Models.Business.SocialCommunication.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

Respresents a message that is specific for the workflow-lib.

## Constructors

### MessageWF()

Default constructor.

```C#
public MessageWF();
```

## Properties 

### MessageCategory

Category of a message.

```C#
public MessageCategory MessageCategory { get; set; }
```

#### Property Value

[MessageCategory](../InformationSystem/MessageCategory.md)

### Subject

Subject of a message.

```C#
public string Subject { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Body

Body of a message.

```C#
public string Body { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### ChannelId

Channel ID.

```C#
public string ChannelId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Channel

Instance of a channel (in chat app).

```C#
public Channel Channel { get; set; }
```

#### Property Value

[Channel](Channel.md)

### SenderId

Sender ID.

```C#
public long SenderId { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

### Sender

Instance of a user, that has sent the message.

```C#
public UserAccount Sender { get; set; }
```

#### Property Value

[UserAccount](../InformationSystem/UserAccount.md)

### RecipientIds

Collection of recipient IDs.

```C#
public ICollection<long> RecipientIds { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)>

### UserRecipients

Collection of instances of a user, that has sent the message.

```C#
public ICollection<UserAccount> UserRecipients { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[UserAccount](../InformationSystem/UserAccount.md)>

### To

Collection of mailbox addresses of recipients.

```C#
public ICollection<MailboxAddress> To { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[MailboxAddress](https://github.com/jstedfast/MimeKit/blob/master/MimeKit/MailboxAddress.cs)>

### Attachments

Collection of attachments of the message.

```C#
public ICollection<Attachment> Attachments { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Attachment](../../Documents/Attachment.md)>

### AttachmentsHttpRequest

Represents the collection of files sent with the HttpRequest.

```C#
public IFormFileCollection AttachmentsHttpRequest { get; set; }
```

#### Property Value

[IFormFileCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iformfilecollection)

### SentAt

Timestamp when the message was sent.

```C#
public DateTime SentAt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

### ReceivedAt

Timestamp when the message was received.

```C#
public DateTime ReceivedAt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

### IsNew

Boolean variable to indicate if the message is new.

```C#
public bool IsNew { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

### IsDeleted

Boolean variable to indicate if the message is deleted.

```C#
public bool IsDeleted { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

### IsReceived

Boolean variable to indicate if the message is received.

```C#
public bool IsReceived { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)
