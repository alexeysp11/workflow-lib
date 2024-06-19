# MessagingService

[English](MessagingService.md) | [Русский](MessagingService.ru.md)

Service for processing messages.

![SystemOverview](../img/SystemOverview.png)

## Description  

- [Search dialog](Processes/Messaging/SearchDialog.md) to start conversation.
- [Loading all messages](Processes/Messaging/StartConversation.md) related to the dialog.
- [Processes messages](Processes/Messaging/ProcessNewMessages.md) from users.
- Client request for [change message status](Processes/Messaging/ChangeMessageStatus.md).
- Uses queues in RabbitMQ to communicate with the **Last seen service** about the status of users (read and write).

## Network messages format

The [ChatMessagingService](../Core/Services/ChatMessagingService.md) class is responsible for processing network requests. 

## Tables in DB

- [chat_users](../DbTables/chat_users.md)
- [chat_message](../DbTables/chat_message.md)
- [chat_cms_request](../DbTables/chat_cms_request.md) (change message status)
- [chat_message_status](../DbTables/chat_message_status.md)
- [chat_conversation](../DbTables/chat_conversation.md)
- [chat_entity_type](../DbTables/chat_entity_type.md)
- [chat_entity_status](../DbTables/chat_entity_status.md)
- [chat_notification_policies](../DbTables/chat_notification_policies.md)
- [chat_e2ee_algorithm_type](../DbTables/chat_e2ee_algorithm_type.md)
