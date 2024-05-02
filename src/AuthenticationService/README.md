# workflow-auth

[English](README.md) | [Русский](README.ru.md)

`workflow-auth` is a service for authentication and getting session tokens.

The authentication service is responsible for verifying the identity of users attempting to access the client app. 
This includes validating user credentials, such as email address and password, and providing secure access to the app's features and functionality.

## Description

The main functions of this authentication service include the following:

- This service writes/reads session tokens in the database.
- PostgreSQL is used as a database.
- In order to reduce the risk of compromise of personal data, the service does not store any data associated with users: only user GUIDs, as well as tables directly related to authentication ("session token", "temporary sign up", "suspicious sign up").
- Only the "code check" table is stored on the client application.
- Any new login to the application updates the expiration date of the session token.

More detailed description of the service is presented at [this link](docs/description.md).

### Goals 

The goals of the project are to provide a service for authentication and session token management, allowing users to securely access the client app's features and functionality.

### Scope 

The scope of the project is focused on providing a specific service for authentication and session token management, rather than a comprehensive library of functionalities.

### Who can use this library

The intended users of the application are developers working on client apps that require authentication and session token management. Companies in a variety of industries could benefit from using this application, particularly those that handle sensitive user data or require secure access to their services.

### What projects this library could be used in

This library could be used in a variety of client app projects that require authentication and session token management, such as e-commerce platforms, social media apps, and financial services apps.

## Technologies

- .NET 6 (C# 10);
- PostgreSQL;
- Entity Framework;
- LINQ;
- WebAPI, gRPC.

## How to use

This service can be used in two main ways:
- as a **component of microservice architecture**,
- as a **library**.

In order to get this library, execute the following operations on the command line:
```
cd C:\PathToProj\your-project
cd ..
git clone https://github.com/alexeysp11/workflow-lib.git
git clone https://github.com/alexeysp11/workflow-auth.git
cd your-project
```

### Using as a microservice

![components](docs/img/components.png)

As an example of an external system that uses this authentication service, you can consider the project [delivery-service-csharp](https://github.com/alexeysp11/delivery-service-csharp):

![authentication](https://github.com/alexeysp11/delivery-service-csharp/raw/main/docs/img/authentication.png)

### Using as a library 

The [ChatCsharp](https://github.com/alexeysp11/ChatCsharp) project uses this authentication service as a library:

![AuthService](https://github.com/alexeysp11/ChatCsharp/raw/main/Docs/img/AuthService.png)

## How to improve this project 

- [TODO](docs/TODO.md)
