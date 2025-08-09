# workflow-lib 

[English](README.md) | [Русский](README.ru.md)

This project is a centralized library that provides a wide range of functions: reusable data models, services, and extensions that are designed to simplify and speed up the development of business applications, particularly in the areas of ERP and CRM.

## Idea

This library was created to solve the problem of code duplication and disparate object models when developing business applications. For example, I often had to create identical entities and services in different projects, which led to a loss of time and complicated support. It is worth noting that each project had its own repository, which complicated the integration between projects and the ability to change the object model.

As a result, it was decided to create a mono-repository, which included most of the previously created projects, as well as a common object model for representing data in the DB. This approach allows:
- Avoid code duplication.
- Ensure data consistency between projects.
- Reduce development time by reusing ready-made components.
- Simplify refactoring and dependency management.

## Projects

### PixelTerminalUI

Example of displaying information in a console application:

```
------------------------------------
                                    |
                                    |
                                    |
                                    |
             WELCOME TO             |
         PIXEL TERMINAL UI          |
                                    |
                                    |
                                    |
                                    |
                                    |
                                    |
                                    |
                                    |
....................................|
                                    |
                                    |
PRESS ENTER TO CONTINUE             |
------------------------------------
```

### UnifiedBusinessPlatform

### Shared

List of the shared projects (reusable data models, services, and extensions):

- [AuthenticationService](src/Shared/AuthenticationService/README.md)
- [CodeExtensions](src/Shared/CodeExtensions/README.md)
- [Communication](src/Shared/Communication/README.md)
- [Models](src/Shared/Models/README.md)
- [Models.Business](src/Shared/Models.Business/README.md)
- [Office](src/Shared/Office/README.md)
- [ServiceDiscoveryBpm](src/Shared/ServiceDiscoveryBpm/README.md)
