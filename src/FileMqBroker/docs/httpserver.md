# httpserver

[English](README.md) | [Русский](README.ru.md)

## Architecture

An example HTTP server architecture is presented below:

![httpserver-architechture](../docs/img/httpserver-architechture.png)

### Controller

The controller must store the following parameters:
- name of the controller and method (for calculating the HTTP path).
- names of HTTP methods (for example, `GET`, `POST`, `PUT` etc).

Also, the controller must be able to parse the request.

### Response handler

The response handler is responsible for processing the response to the request after the adapter implements the `IReadAdapter` interface.

The response is processed as follows:
- Response handler implements the processing method.
- The delegate (link to the processing method) is stored in `AppInitConfigs`.
- An object of the `AppInitConfigs` class is passed to the constructor of the adapter that implements the `IReadAdapter` interface, and the delegate is saved as a member of the class.
- When an adapter implementing the `IReadAdapter` interface processes a request, a delegate is called to process the request.
