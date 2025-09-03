# DataStorage

[English](README.md) | [Русский](README.ru.md)

This project is designed to study and implement various types of data storage, as well as to study the principles of building distributed systems.

Project goal: in-depth understanding of the architecture, features and optimization methods of various data storages, from relational databases to key-value and key-attribute-value storages, both in-memory and persistent implementations.

**Main tasks and features of the project:**

- **Support for various types of data storage:**
    - Relational databases (example: SQLite, PostgreSQL)
    - Key-Value storages (example: Redis, RocksDB)
    - Key-Attribute-Value storages
    - In-Memory and Persistent implementations for each type.
- **Implementation of gRPC services:**
    - Each type of storage is deployed as a separate gRPC service, providing an API for interacting with data.
- **Distributed architecture:**
    - Support for deploying storage as a distributed system with:
        - Data replication for fault tolerance.
        - Data synchronization between replicas.
        - Data sharding for scalability.
- **Containerization (Docker):**
    - All services are deployed in Docker containers to simplify deployment and management.

**Technologies:**

- C# (.NET)
- gRPC
- Docker

**Project status:**

The project is under active development. The following has been implemented (or is planned to be implemented) at the moment:

- [x] Basic implementation of Key-Value storage (in-memory)
- [x] gRPC service for Key-Value storage
- [ ] Dockerfile for Key-Value service
- [ ] Data replication for Key-Value storages
