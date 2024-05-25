# workflow-lib 

[English](README.md) | [Русский](README.ru.md)

Этот проект представляет собой комплексную библиотеку, предоставляющую широкий спектр функций для ERP/CRM-систем.

В целом, эта библиотека представляет собой мощный инструмент, который можно использовать в ERP/CRM-системах для оптимизации и автоматизации различных бизнес-процессов.
Она предлагает широкий спектр функций и моделей данных, которые можно настроить в соответствии с конкретными потребностями любой организации.

Кто может использовать данную библиотеку:
- Разработчики, работающие над приложениями, которым требуются функции, предоставляемые библиотекой, могут использовать это приложение.
- Компании в таких отраслях, как логистика, финансы и управление документами, потенциально могут получить выгоду от использования приложений, включающих эту библиотеку.

## Проекты внутри библиотеки

- [AuthenticationService](src/AuthenticationService/README.ru.md)
- [CodeExtensions](src/CodeExtensions/README.ru.md)
- [Communication](src/Communication/README.ru.md)
- [Models](src/Models/README.ru.md)
- [Models.Business](src/Models.Business/README.ru.md)
- [Office](src/Office/README.ru.md)
- [ServiceDiscoveryBpm](src/ServiceDiscoveryBpm/README.ru.md)

## Технологии 

- Фреймворки .NET:
  - .NET Core 3.1 (C# 8.0)
  - .NET 6 (C# 10)
- [itext7](https://github.com/itext/itext7-dotnet)
- [itext7.pdfhtml](https://github.com/itext/i7n-pdfhtml)
- [Open XML SDK](https://github.com/dotnet/Open-XML-SDK)
- [Open-Xml-PowerTools](https://github.com/alexeysp11/Open-Xml-PowerTools.git)
- [RabbitMQ](https://github.com/rabbitmq/rabbitmq-dotnet-client)
- [MailKit](https://github.com/jstedfast/MailKit) и [MimeKit](https://github.com/jstedfast/MimeKit)
- [Nethereum.Web3](https://github.com/Nethereum/Nethereum/tree/master/src/Nethereum.Web3)

## Рекомендации к использованию 

Данную библитеку возможно использовать напрямую из C# кода: 

1. Склонировать репозиторий: 
```
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git 
git clone https://github.com/alexeysp11/workflow-lib.git
```

2. В `csproj` файле таргет-проекта добавить ссылку на данный репозиторий: 
```XML
  <ItemGroup>
    <ProjectReference Include="../../workflow-lib/src/WorkflowLib.csproj" />
  </ItemGroup>
```
