# Example02

[English](README.md) | [Русский](README.ru.md)

The example is related to initializing data regarding settings of microservice communication (without adding data to the database).

Let's say there is a requirement that communication between backend services be as flexible as possible (for example, as shown in the figure below).
In this case, it is assumed that a common database will be used in which the details of interservice communication will be stored.

![layers_simplified](https://github.com/alexeysp11/delivery-service-csharp/raw/main/docs/img/layers_simplified.png)

## Endpoints

Based on the diagram presented above, the endpoints will be the following elements:
- Backend service A
- Backend service B
- ESB proxy
- ESB writer
- ESB reader
