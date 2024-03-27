# ServiceInteraction

[English](README.md) | [Русский](README.ru.md)

Let's imagine that there are several components that "communicate" with each other, as shown in the figure below.

![ServiceInteraction](../../docs/img/examples/ServiceInteraction.png)

There are several points regarding the implementation of components and communication between them:
- these components are implemented as classes in the C# library;
- components communicate not directly, but through a "resolver":
     - the "resolver" accesses the database in order to obtain information about the type of interaction.

There are several types of shells:
- monolith;
- HTTP;
- gRPC.

![ServiceDiscoveryArchitecture](../../docs/img/examples/ServiceDiscoveryArchitecture.png)

Algorithms for selecting an endpoint in a distributed system:
- **Random**: A simple and effective method, but can lead to inefficient use of resources, especially if one of the instances is overloaded.
- **Round-robin**: Evenly distributes requests between instances, which helps balance the load. However, it does not take into account the current load of instances.
- **Select the least loaded service**: This method allows you to select the instance with the least load, which can improve performance and resource efficiency (i.e. estimates the total load on the server, including CPU time, CPU load, memory usage, number of active requests, network speed, number of processed requests per unit of time and other parameters).
- **Least Connections**: Select the service with the least number of active connections.
- **Weighted Round-robin**: Distribution of requests taking into account the weights of instances (for example, more powerful servers receive more weight).
- **Least Response Time**: Select the service with the shortest response time.

## EndpointPool

There is a collection that stores objects of type `EndpointCollectionParameter` (i.e. information about active endpoints). But it happens that an endpoint becomes temporarily unavailable; accordingly, such an endpoint will need to be removed from the collection. However, this object will remain on the heap until it is removed by the garbage collector. The problem is that when the connection to the endpoint is restored, you will need to create exactly the same endpoint in memory (thus, there will be two endpoints in the managed heap, which is not very correct from the point of view of memory use).

To solve this problem, it is proposed to use the `EndpointPool` class, which will manage the allocation/deallocation of endpoints in memory, implementing the [object pool pattern](https://en.wikipedia.org/wiki/Object_pool_pattern).
