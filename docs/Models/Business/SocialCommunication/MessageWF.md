# MessageWF Class 

Namespace: [Cims.WorkflowLib.Models.Business.SocialCommunication](Cims.WorkflowLib.Models.Business.SocialCommunication.md)

Respresents a message that is specific for the workflow-lib.

## Constructors

### MessageWF()

Default constructor.

```C#
public MessageWF();
```

## Properties 

### Id

ID of a message.

```C#
public long Id { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

ID of a message.

### Uid

UID of a message.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of a message.

### Description

Description of a message.

```C#
public string Description { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Description of a message.

### MessageCategory

Category of a message.

```C#
public MessageCategory MessageCategory { get; set; }
```

#### Property Value

[MessageCategory](../InformationSystem/MessageCategory.md)

Category of a message.

### Subject

Subject of a message.

```C#
public string Subject { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Subject of a message.

### Body

Body of a message.

```C#
public string Body { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Body of a message.

### ChannelId

Channel ID.

```C#
public string ChannelId { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Channel ID.

### Channel

Instance of a channel (in chat app).

```C#
public Channel Channel { get; set; }
```

#### Property Value

[Channel](Channel.md)

Instance of a channel.

### SenderId

Sender ID.

```C#
public long SenderId { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

Sender ID.

### Sender

Instance of a user, that has sent the message.

```C#
public UserAccount Sender { get; set; }
```

#### Property Value

[UserAccount](../InformationSystem/UserAccount.md)

Instance of a user, that has sent the message.

### RecipientIds

Collection of recipient IDs.

```C#
public ICollection<long> RecipientIds { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)>

Collection of recipient IDs.

### UserRecipients

Collection of instances of a user, that has sent the message.

```C#
public ICollection<UserAccount> UserRecipients { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[UserAccount](../InformationSystem/UserAccount.md)>

Collection of instances of a user, that has sent the message.

### To

Collection of mailbox addresses of recipients.

```C#
public ICollection<MailboxAddress> To { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[MailboxAddress](https://github.com/jstedfast/MimeKit/blob/master/MimeKit/MailboxAddress.cs)>

Collection of mailbox addresses of recipients.

### Attachments

Collection of attachments of the message.

```C#
public ICollection<Attachment> Attachments { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Attachment](../../Documents/Attachment.md)>

Collection of attachments of the message.

### AttachmentsHttpRequest

Represents the collection of files sent with the HttpRequest.

```C#
public IFormFileCollection AttachmentsHttpRequest { get; set; }
```

#### Property Value

[IFormFileCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iformfilecollection)

Represents the collection of files sent with the HttpRequest.

### SentAt

Timestamp when the message was sent.

```C#
public DateTime SentAt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Timestamp when the message was sent.

### ReceivedAt

Timestamp when the message was received.

```C#
public DateTime ReceivedAt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Timestamp when the message was received.

### IsNew

Boolean variable to indicate if the message is new.

```C#
public bool IsNew { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Boolean variable.

### IsDeleted

Boolean variable to indicate if the message is deleted.

```C#
public bool IsDeleted { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Boolean variable.

### IsReceived

Boolean variable to indicate if the message is received.

```C#
public bool IsReceived { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Boolean variable.
