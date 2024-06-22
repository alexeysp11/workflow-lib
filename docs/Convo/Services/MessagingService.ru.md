# MessagingService

[English](MessagingService.md) | [Русский](MessagingService.ru.md)

Сервис обработки сообщений.

![SystemOverview](../img/SystemOverview.png)

## Описание 

- [Выбор собеседника](Processes/Messaging/SearchDialog.ru.md) для начала общения.
- [Загрузка переписки](Processes/Messaging/StartConversation.ru.md) с собеседником.
- [Обрабатывает сообщения](Processes/Messaging/ProcessNewMessages.ru.md) от пользователей.
- Клиентский запрос на [изменение статуса сообщения](Processes/Messaging/ChangeMessageStatus.ru.md).
- Использует очереди в RabbitMQ для коммуникации с сервисом **Last seen service** по поводу статуса пользователей (чтение и запись). 

## Описание сетевого взаимодействия 

За обработку сетевых запросов ответственен класс [ChatMessagingService](../Core/Services/ChatMessagingService.md).

## Таблицы в БД

- [chat_users](../DbTables/chat_users.md)
- [chat_message](../DbTables/chat_message.md)
- [chat_cms_request](../DbTables/chat_cms_request.md) (change message status)
- [chat_message_status](../DbTables/chat_message_status.md)
- [chat_conversation](../DbTables/chat_conversation.md)
- [chat_entity_type](../DbTables/chat_entity_type.md)
- [chat_entity_status](../DbTables/chat_entity_status.md)
- [chat_notification_policies](../DbTables/chat_notification_policies.md)
- [chat_e2ee_algorithm_type](../DbTables/chat_e2ee_algorithm_type.md)
