# LastSeenService

[English](LastSeenService.md) | [Русский](LastSeenService.ru.md)

Service for processing the time of last user activity.

![SystemOverview](../img/SystemOverview.png)

## Description 

- Whenever the app gets a request from the user, it notifies the **last seen service**.
- Ping each user if they don't take any action within 5-15 minutes.
- Functionalities:
    - Last online (sign in, sign out)
    - Last sent a message
    - Last received a message 

## Objects 

- User 
- Message 
- Activity (type of activity, datetime, )
- Type of activity (sign in, sign out, sent a message, received a message)
