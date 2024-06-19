# GroupService

[English](MessagingService.md) | [Русский](MessagingService.ru.md)

Сервис обработки сообщений в группах 

![SystemOverview](../img/SystemOverview.png)

## Описание 

По функционалу почти полностью повторяет сервис [MessagingService](MessagingService.ru.md), отличия приведены ниже:
- Название БД: `UserGroupDB`.

## Таблицы в БД

Некоторые таблицы в БД идентичны таблицам в сервисе [MessagingService](MessagingService.ru.md):
- user - идентично; 
- message - идентично;
- change_status_request - идентично;
- message_status - идентично;
- chat_entity_type - идентично;
- chat_entity_status - идентично;
- notification_policies - идентично;
- group: 
    - `group_id: varchar not null`, 
    - `uid: varchar not null`,
    - `name: varchar not null`,
    - `image: blob`, 
    - `description: varchar`.
- group_user: 
    - `group_user_id: integer not null`, 
    - `group_id: varchar not null` -> group,
    - `user_id: varchar not null` -> user,
    - `notification_policies_id: integer` -> notification_policies.
- message_user:
    - `message_user_id: integer not null`,
    - `message_id: integer not null` -> message,
    - `user_id: integer not null` -> user,
    - `message_status_id: integer` -> message_status.
