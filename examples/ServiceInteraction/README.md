# ServiceInteraction

[English](README.md) | [Русский](README.ru.md)

Let's imagine that there are several components that “communicate” with each other, as shown in the figure below.

![ServiceInteraction](../../docs/img/examples/ServiceInteraction.png)

There are several points regarding the implementation of components and communication between them:
- these components are implemented as classes in the C# library;
- components communicate not directly, but through a “resolver”:
     - the “resolver” accesses the database in order to obtain information about the type of interaction.

There are several types of shells:
- monolith;
- HTTP;
- gRPC.

![ExplicitImplicitCall](../../docs/img/examples/ExplicitImplicitCall.png)
