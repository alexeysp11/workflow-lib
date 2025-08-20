# DataStorage

[English](README.md) | [Русский](README.ru.md)

An application that performs the functions of an in-memory database on the .NET platform.

The purpose of this application is to, on the one hand, better understand the fundamental concepts of database operation at a low level (query execution plan, multi-versioning, isolation levels, concurrency), and also to improve your knowledge of the .NET platform (for example, garbage collection, memory allocation control , dynamic compilation).

The following functionality is also expected to be used:
- implementation of triggers, stored functions/procedures, indexes.
- tools for saving the history of completed operations and analyzing completed operations.
- tools for analyzing the query execution plan.

## Requirements

The basic requirements for an application that performs the functions of an in-memory database may be as follows:

1. In-memory storage: The application must provide in-memory storage for fast access and operations.
2. Multiversion and isolation levels: Supports multiversion of data and various levels of transaction isolation to ensure data integrity.
3. Implementation of triggers, stored functions/procedures, indexes: Ability to create and use triggers, stored functions/procedures and indexes to optimize work with data.
4. Tools for saving the history of completed operations: Functionality for saving the history of completed operations with the ability to analyze and restore data.
5. Tools for query execution plan analysis: The ability to analyze and optimize the query execution plan to improve application performance.
6. Data security: Ensuring data protection from unauthorized access and the ability to backup data.
7. Scalability: Ability to scale the application to handle large amounts of data and users.
8. Memory Management: Efficient memory management, garbage collection and memory allocation control to optimize performance.
9. Documentation and debugging tools: Availability of detailed documentation on the functionality of the application and tools for debugging and monitoring the operation of the application.
10. Support for various data types and queries: Ability to work with various data types (text, numeric, time, etc.) and support a variety of data queries.
11. Efficiency and performance: Ensuring high performance when processing queries and data operations.
12. Testing and updating: Availability of mechanisms for testing the functionality of the application and updating it with minimal impact on the operation of the system.
