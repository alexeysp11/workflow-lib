# workflow-lib 

Доступно на других языках: [English/Английский](README.md), [Russian/Русский](README.ru.md). 

`workflow-lib` - это библиотека на C#, состоящая из:
- [Динамической компиляции кода на C#](docs/Dynamical/DynamicCompiling.md);
- Базы данных: [SQLite](docs/DbConnections/SqliteDbConnection.md), [PostgreSQL](docs/DbConnections/PgDbConnection.md), [MySQL](docs/DbConnections/MysqlDbConnection.md), [MS SQL](docs/DbConnections/MssqlDbConnection.md), [Oracle](docs/DbConnections/OracleDbConnection.md);
- Сетевое взаимодействие и APIs: 
    - HTTP: [sender](docs/NetworkAPIs/HttpSender.md), 
    - TCP: [client](docs/NetworkAPIs/TcpClientWF.md), [listener](docs/NetworkAPIs/TcpListenerWF.md), 
    - Email sender: [MimeKit based](docs/NetworkAPIs/EmailSenderMimeKit.md);
- Документы и операции с документами (запись, чтение, конвертация): 
    - Общие: [вложение](docs/Models/Documents/Attachment.md), [spreadsheet-элемент](docs/Models/Documents/SpreadsheetElement.md), [элемент текстового документа](docs/Models/Documents/TextDocElement.md).
    - Текстовые: [MS Word](docs/DocFormats/TextBased/MSWordConverter.md) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), [TXT](docs/DocFormats/TextBased/TxtConverter.md);
    - Spreadsheets-таблицы: [MS Excel](docs/DocFormats/Spreadsheets/MSExcelConverter.md) (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
    - [PDF](docs/DocFormats/PdfConverter.md);
    - Изображения: [PNG](docs/DocFormats/Images/PngConverter.md), [BMP](docs/DocFormats/Images/BmpConverter.md), [JPEG](docs/DocFormats/Images/JpegConverter.md), SVG, GIF, ICO;
    - XML, JSON, OOXML, CSV;
    - [Binary](docs/DocFormats/BinaryConverter.md);
- Классы для бизнеса:
    - Общее: [адрес](docs/Models/Business/Address.md), [бизнес-операция](docs/Models/Business/BusinessOperation.md), [период](docs/Models/Business/Period.md), [риск](docs/Models/Business/Risk.md), etc.
    - Бизнес-документы: [счёт](docs/Models/Business/BusinessDocuments/Bill.md), [заказ на доставку](docs/Models/Business/BusinessDocuments/DeliveryOrder.md), [трудовой договор](docs/Models/Business/BusinessDocuments/EmploymentContract.md), etc.
    - Потербители: [потребитель](docs/Models/Business/Customers/Customer.md), [компания](docs/Models/Business/Customers/Company.md), [contact](docs/Models/Business/Customers/Contact.md), etc.
    - Информационная система: [работник](docs/Models/Business/InformationSystem/Employee.md), [аккаунт пользователя](docs/Models/Business/InformationSystem/UserAccount.md), [рабочий день](docs/Models/Business/InformationSystem/WorkingDay.md), etc.
    - Деньги: [зарплата/чек оплаты](docs/Models/Business/Monetary/Paycheck.md), [оплата](docs/Models/Business/Monetary/Payment.md), [ставка оплаты](docs/Models/Business/Monetary/PayRate.md), etc.
    - Продукты: [продукт](docs/Models/Business/Products/Product.md), [категория продукта](docs/Models/Business/Products/ProductCategory.md), [проект](docs/Models/Business/Products/Project.md).
    - Обязанности: [обязанности работника](docs/Models/Business/Responsibilities/EmployeeResponsibility.md), [обязанности работодателя](docs/Models/Business/Responsibilities/EmployerResponsibility.md).
<!--
- Визуализация данных: Line chart, Bar chart, Histogram, Scatter plot, Box plot, Pareto chart, Pie chart, Area chart, Tree map, Bubble chart, Stripe graphic, Control chart, Run chart, Stem-and-leaf display, Cartogram, Small multiple, Sparkline, Table, Marimekko chart. 
-->

Документация по неймспейсам и типам данных, используемых в библиотеке, представлена по [данной ссылке](docs/documentation.md).

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

## Рекомендации к использованию 

Данную библитеку возможно использовать напрямую из C# кода: 

1. Склонировать репозиторий (предполагается, что `csproj` файл таргет-проекта расположен по адресу `C:\PathToProj\your-project`): 
```
cd C:\PathToProj\your-project
cd ..
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git 
git clone https://github.com/alexeysp11/workflow-lib.git
cd your-project
```

2. В `csproj` файле таргет-проекта добавить ссылку на данный репозиторий: 
```XML
  <ItemGroup>
    <ProjectReference Include="../../workflow-lib/src/Cims.WorkflowLib.csproj" />
  </ItemGroup>
```
<!--
## Как использовать данную библиотеку совместно с XML/JSON оболочкой  

Подразумевается использование данной библиотеки с помощью XML/JSON оболочки (своего рода no-code подход).
-->

## Как улучшить библиотеку 

- [TODO](docs/TODO.md)