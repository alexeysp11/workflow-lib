# Communication

[English](README.md) | [Русский](README.ru.md)

Данная часть библиотеки предоставляет функционал для сетевого взаимодействия и APIs: 
- Сетевое взаимодействие: 
    - HTTP: [sender](NetworkAPIs/HttpSender.md), [server](NetworkAPIs/HttpServerWF.md), 
    - TCP: [client](NetworkAPIs/TcpClientWF.md), [listener](NetworkAPIs/TcpListenerWF.md), 
- Email sender: [MimeKit based](NetworkAPIs/EmailSenderMimeKit.md);
- Ethereum: [Nethereum.Web3](NethereumAPI/EthNodeAPIWeb3.md).

Кроме того, библиотека обеспечивает связь с Ethereum с помощью библиотеки Nethereum.Web3, предоставляя доступ к технологии блокчейна. 

## Технологии 

- Фреймворки .NET:
  - .NET Core 3.1
  - .NET 6
- [RabbitMQ](https://github.com/rabbitmq/rabbitmq-dotnet-client)
- [MailKit](https://github.com/jstedfast/MailKit) и [MimeKit](https://github.com/jstedfast/MimeKit)
- [Nethereum.Web3](https://github.com/Nethereum/Nethereum/tree/master/src/Nethereum.Web3)
