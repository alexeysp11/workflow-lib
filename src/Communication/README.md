# Communication

[English](README.md) | [Русский](README.ru.md)

This part of the library provides functionality for network interaction and APIs:
- Network APIs and operations: 
    - HTTP: [sender](NetworkAPIs/HttpSender.cs), [server](NetworkAPIs/HttpServerWF.cs), 
    - TCP: [client](NetworkAPIs/TcpClientWF.cs), [listener](NetworkAPIs/TcpListenerWF.cs), 
- Email sender: [MimeKit based](NetworkAPIs/EmailSenderMimeKit.cs);
- Ethereum: [Nethereum.Web3](NethereumAPI/EthNodeAPIWeb3.cs).

In addition, the library enables communication with Ethereum using Nethereum.Web3 library, providing access to blockchain technology. 

## Technologies 

- Target frameworks:
  - .NET Core 3.1
  - .NET 6
- [RabbitMQ](https://github.com/rabbitmq/rabbitmq-dotnet-client)
- [MailKit](https://github.com/jstedfast/MailKit) and [MimeKit](https://github.com/jstedfast/MimeKit)
- [Nethereum.Web3](https://github.com/Nethereum/Nethereum/tree/master/src/Nethereum.Web3)
