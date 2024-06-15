# TODO 

- Add functionality for **notifying** other services **about session tokens**: 
    - Parameters that could be specified in **config file**:
        - HTTP, TCP, AMQP (RabbitMQ);
        - IP addresses.
- Add functionality for **interacting with DB**:
    - Parameters that could be specified in **config file**:
        - Type: SQLite, PostgreSQL, MySQL, MS SQL.
        - SQL, Entity Framework.
        - Connection string.
- Add IP addresses and/or MQ into **config file**.
- **IP address** could be added to the `session_token`.
- Add **two-factor authentication**.
- Add functionality for **restoring a password**.
- Consider to add **JWT** into the service.
- Add **middleware pipeline** for the following cases:
    - In general, *handling request/response*, *redirection* and *DB operations* could be implemented as separate middlewares.
    - When adding a new user, *sending verification code* could be separated as well.

![request-delegate-pipeline](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/index/_static/request-delegate-pipeline.png?view=aspnetcore-3.1)

- Remove all the unnecessary classes and methods: `CheckUserExistance`, `UserExistance`.
- When user gets session token, is it necessary to return an array of overriden tokens?
- When a user gets session token, there's a potential threat that an attacker could generate user UID and get session their token.
