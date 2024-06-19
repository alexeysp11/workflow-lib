# ChatMessagingService Class 

*Namespace*: [Chat.Core.Services](Chat.Core.Services.md)

Service for processing messages.

## Constructors 

### ChatMessagingService()

Default constructor.

```C#
public ChatMessagingService();
```

## Methods

### SendMessage(SendMsgRequestDTO)

Sending messages.

```C#
public SendMsgResponseDTO SendMessage(SendMsgRequestDTO request);
```

#### Parameters 

- `request`: [SendMsgRequestDTO](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/SocialCommunication/DTOs/SendMsgRequestDTO.md)

Request.

#### Returns 

[SendMsgResponseDTO](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/SocialCommunication/DTOs/SendMsgResponseDTO.md)

Response.

### GetMessages(GetMsgRequestDTO)

Getting messages.

```C#
public GetMsgResponseDTO GetMessages(GetMsgRequestDTO request);
```

#### Parameters 

- `request`: [GetMsgRequestDTO](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/SocialCommunication/DTOs/GetMsgRequestDTO.md)

Request.

#### Returns 

[GetMsgResponseDTO](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/SocialCommunication/DTOs/GetMsgResponseDTO.md)

Response.

### ChangeMessageStatus(SetMsgStatusRequestDTO)

Change message status.

```C#
public SetMsgStatusResponseDTO GetMessages(SetMsgStatusRequestDTO request);
```

#### Parameters 

- `request`: [SetMsgStatusRequestDTO](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/SocialCommunication/DTOs/SetMsgStatusRequestDTO.md)

Request.

#### Returns 

[SetMsgStatusResponseDTO](https://github.com/alexeysp11/workflow-lib/blob/main/docs/Models/Business/SocialCommunication/DTOs/SetMsgStatusResponseDTO.md)

Response.
