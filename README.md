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

### [PixelTerminalUI](src/PixelTerminalUI/README.md)

`PixelTerminalUI` was inspired by my experience working as a C# developer at a large IT company that operated a major marketplace. I worked in the WMS department, developing applications for internal logistics. One of the key applications was a legacy Telnet UI application used for interacting with handheld terminals (PDAs).

As the company sought to modernize its development practices with CI/CD, challenges arose in building and deploying .NET Framework 4.8 applications. Intrigued by how this application achieved a full UI experience using simple characters, I decided to explore its inner workings.

This led to the creation of `PixelTerminalUI`, a project aimed at reimagining the engine behind this Telnet UI application. It serves as a demonstration of how to create a character-based UI framework in modern .NET.

`PixelTerminalUI` is a completely independent project, developed in my free time and does not contain any code or confidential information from my previous employer.

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
- [Models.Business](src/Shared/Models.Business/README.md): is an implementation of a shared object model for business entities used within [workflow-lib](https://github.com/alexeysp11/workflow-lib).
- [Office](src/Shared/Office/README.md)
- [ServiceDiscoveryBpm](src/Shared/ServiceDiscoveryBpm/README.md)
