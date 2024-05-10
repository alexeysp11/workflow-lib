# ServiceInteraction

[English](README.md) | [Русский](README.ru.md)

There are several components that "communicate" with each other, as shown in the figure below.

![ServiceInteraction](../../../docs/img/examples/ServiceInteraction.png)

Regarding communication between components, several points can be highlighted:
- The components communicate not directly, but through the [ServiceDiscoveryBpm](../../../src/ServiceDiscoveryBpm/README.md) library.
- Details of communication with the database are implemented on the side of the application that implements the business logic.

There are several types of client applications:
- monolith;
- HTTP;
- gRPC.

## Sequence of request processing on services

### Customer

![ServiceInteraction_CustomerService](../../../docs/img/examples/ServiceInteraction_CustomerService.png)
