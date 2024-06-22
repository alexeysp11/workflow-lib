# Description

[English](Description.md) | [Русский](Description.ru.md)

## Requirements

### Functional requirements 

- One-one chat.
- Group chat.
- Read receipt.
- Online status.
- Notifications.
- Share multimedia.

### System requirements

- Low latency.
- High reliability.
- High availability.
- Web, mobile, desktop.
- Chat history. 
- High BLOB store.
- E2E encryption.
- Web sockets.

### Capacity planning

- Total active users: 500M.
- Every user sends 30 messages per day (in average).
- Total messages per day: `500M * 30 = 1500M = 1.5B`.
- Messages per second: `1.5B / (3600 * 24) = 18K`

### Storage estimation 

How to calculate the size of a database? 

- Total messages per day: 1.5B.
- Each message: 50 kB.
- Total storage: `1.5B * 50kB = 75 pB`.

## Services 

- [Messaging service](Services/MessagingService.md)
- [Group service](Services/MessagingService.md)
- [Authentication service](Services/AuthenticationService.md)
- [Last seen service](Services/LastSeenService.md)
- [Asset service](Services/AssetService.md)

Service communication diagram:

![SystemOverview](img/SystemOverview.png)
