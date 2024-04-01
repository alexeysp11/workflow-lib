# workflow-lib 

[English](README.md) | [Русский](README.ru.md)

Этот проект представляет собой комплексную библиотеку, предоставляющую широкий спектр функций для ERP-систем.

В целом, эта библиотека представляет собой мощный инструмент, который можно использовать в ERP-системах для оптимизации и автоматизации различных бизнес-процессов.
Она предлагает широкий спектр функций и моделей данных, которые можно настроить в соответствии с конкретными потребностями любой организации.

## Общее описание

`workflow-lib` - это библиотека на C#, состоящая из:
- [Динамической компиляции кода на C#](docs/Dynamical/DynamicCompiling.md);
- Конфигурация: [JSON](docs/Extensions/JsonConfigExtensions.md), XML;
- Базы данных: [SQLite](docs/DbConnections/SqliteDbConnection.md), [PostgreSQL](docs/DbConnections/PgDbConnection.md), [MySQL](docs/DbConnections/MysqlDbConnection.md), [MS SQL](docs/DbConnections/MssqlDbConnection.md), [Oracle](docs/DbConnections/OracleDbConnection.md);
- Сетевое взаимодействие и APIs: 
    - HTTP: [sender](docs/NetworkAPIs/HttpSender.md), [server](docs/NetworkAPIs/HttpServerWF.md), 
    - TCP: [client](docs/NetworkAPIs/TcpClientWF.md), [listener](docs/NetworkAPIs/TcpListenerWF.md), 
    - Email sender: [MimeKit based](docs/NetworkAPIs/EmailSenderMimeKit.md);
- Ethereum: [Nethereum.Web3](docs/NethereumAPI/EthNodeAPIWeb3.md);
- Документы и операции с документами (запись, чтение, конвертация): 
    - Общие: [вложение](docs/Models/Documents/Attachment.md), [spreadsheet-элемент](docs/Models/Documents/SpreadsheetElement.md), [элемент текстового документа](docs/Models/Documents/TextDocElement.md).
    - Текстовые: [MS Word](docs/DocFormats/TextBased/MSWordConverter.md) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), [TXT](docs/DocFormats/TextBased/TxtConverter.md);
    - Spreadsheets-таблицы: [MS Excel](docs/DocFormats/Spreadsheets/MSExcelConverter.md) (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
    - [PDF](docs/DocFormats/PdfConverter.md);
    - Изображения: [PNG](docs/DocFormats/Images/PngConverter.md), [BMP](docs/DocFormats/Images/BmpConverter.md), [JPEG](docs/DocFormats/Images/JpegConverter.md), SVG, GIF, ICO;
    - XML, JSON, OOXML, CSV;
    - HTML, markdown;
    - [Binary](docs/DocFormats/BinaryConverter.md);
- Классы для бизнеса:
    - Общее: [адрес](docs/Models/Business/Address.md), [бизнес-задача](docs/Models/Business/BusinessTask.md), [период](docs/Models/Business/Period.md), [риск](docs/Models/Business/Risk.md), etc.
    - Бизнес-документы: [счёт](docs/Models/Business/BusinessDocuments/Bill.md), [заказ на доставку](docs/Models/Business/BusinessDocuments/DeliveryOrder.md), [трудовой договор](docs/Models/Business/BusinessDocuments/EmploymentContract.md), etc.
    - Потербители: [потребитель](docs/Models/Business/Customers/Customer.md), [компания](docs/Models/Business/Customers/Company.md), [contact](docs/Models/Business/Customers/Contact.md), etc.
    - Информационная система: [работник](docs/Models/Business/InformationSystem/Employee.md), [аккаунт пользователя](docs/Models/Business/InformationSystem/UserAccount.md), [рабочий день](docs/Models/Business/InformationSystem/WorkingDay.md), etc.
    - Деньги: [зарплата/чек оплаты](docs/Models/Business/Monetary/Paycheck.md), [оплата](docs/Models/Business/Monetary/Payment.md), [ставка оплаты](docs/Models/Business/Monetary/PayRate.md), etc.
    - Продукты: [продукт](docs/Models/Business/Products/Product.md), [категория продукта](docs/Models/Business/Products/ProductCategory.md), [проект](docs/Models/Business/Products/Project.md).
    - Обязанности: [обязанности работника](docs/Models/Business/Responsibilities/EmployeeResponsibility.md), [обязанности работодателя](docs/Models/Business/Responsibilities/EmployerResponsibility.md).
    - Социальное общение: [сообщение](docs/Models/Business/SocialCommunication/MessageWF.md).
<!--
- Визуализация данных: Line chart, Bar chart, Histogram, Scatter plot, Box plot, Pareto chart, Pie chart, Area chart, Tree map, Bubble chart, Stripe graphic, Control chart, Run chart, Stem-and-leaf display, Cartogram, Small multiple, Sparkline, Table, Marimekko chart. 
-->

Документация по неймспейсам и типам данных, используемых в библиотеке, представлена по [данной ссылке](docs/documentation.md).

### Цель

Цель этой библиотеки — предоставить набор предварительно написанного кода, который вы можете использовать для выполнения задач, специфичных для вашего проекта.

Эта библиотека включает динамическую компиляцию кода C#, что обеспечивает гибкость и настройку при разработке системы.
Библиотека также предлагает операции с такими базами данных, как SQLite, PostgreSQL, MySQL, MS SQL, Oracle, что упрощает извлечение и вставку данных из различных источников.

Кроме того, библиотека обеспечивает связь с Ethereum с помощью библиотеки Nethereum.Web3, предоставляя доступ к технологии блокчейна. Библиотека также предлагает операции с документами, поддерживающими несколько форматов, таких как MS word (doc, docx), MS Excel (XLS, XLSX), PDF, изображения (PNG, BMP, JPEG) и бинарные файлы.

Библиотека включает в себя несколько классов для бизнеса, таких как общие модели данных, такие как адрес, бизнес-операция, период, риск и т.д.
Он также включает классы для деловых документов, таких как счет, заказ на доставку, трудовой договор, клиенты, такие как клиент, компания, контакт, информационная система, такая как сотрудник, учетная запись пользователя, рабочий день, денежные модели, такие как зарплата, оплата, ставка заработной платы и продукты, такие как продукт, продукт. категория, проект.
Кроме того, в библиотеке предусмотрены занятия по таким обязанностям, как ответственность сотрудников, ответственность работодателя и социальное общение, например сообщения.

### Область применения

Область применения проекта ориентирована на предоставление библиотеки функций и моделей данных для использования в других приложениях, а не в отдельном приложении.

### Кто может использовать эту библиотеку

Разработчики, работающие над приложениями, которым требуются функции, предоставляемые библиотекой, могут использовать это приложение.
Компании в таких отраслях, как логистика, финансы и управление документами, потенциально могут получить выгоду от использования приложений, включающих эту библиотеку.

### В каких проектах можно использовать эту библиотеку

Эту библиотеку можно использовать в различных проектах, требующих динамической компиляции, операций с базами данных, связи с Ethereum и обработки документов. Примеры могут включать приложения для управления логистикой, финансовой торговли и совместной работы с документами.

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
<!--
## Как использовать данную библиотеку совместно с XML/JSON оболочкой  

Подразумевается использование данной библиотеки с помощью XML/JSON оболочки (своего рода no-code подход).
-->

## Как улучшить библиотеку 

- [TODO](docs/TODO.md)