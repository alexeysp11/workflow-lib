# AuthenticationService

[English](AuthenticationService.md) | [Русский](AuthenticationService.ru.md)

Service for authentication and getting session tokens.

![SystemOverview](../img/SystemOverview.png)

## Description of the authentication API

- This service writes/reads session tokens in the database and notifies [Last seen service](LastSeenService.ru.md) about issuing a session token to a specific user.
- PostgreSQL is used as a database.
- In order to reduce the risk of compromise of personal data, the service does not store any data associated with users: only user GUIDs, as well as tables related to authentication (“session token”, “temporary registration”, “suspicious registration”).
- Only the “code check” table is stored on the client application.
- Any new login to the application updates the expiration date of the session token.

The [workflow-auth](https://github.com/alexeysp11/workflow-auth) *external service*/*library* is used as an authentication service.
The communication diagram between services is shown in the figure below:

![AuthService](../img/AuthService.png)

In this authentication service, the [ChatAuthService](../Core/Services/ChatAuthService.md) class is responsible for processing network requests.

## Tables in the database

- [chat_users](../DbTables/chat_users.md)
