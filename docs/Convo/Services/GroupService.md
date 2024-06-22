# GroupService

[English](GroupService.md) | [Русский](GroupService.ru.md)

Service for processing group messages 

![SystemOverview](../img/SystemOverview.png)

## Description 

The functionality is almost identical to the service [MessagingService](MessagingService.ru.md), the differences are listed below:
- Database name: `UserGroupDB`. 

## Tables in database 

Some tables in the database are identical to tables in the service [MessagingService](MessagingService.ru.md):
- user - identical; 
- message - identical;
- change_status_request - identical;
- message_status - identical;
- chat_entity_type - identical;
- chat_entity_status - identical;
- notification_policies - identical;
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
