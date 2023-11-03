# workflow-lib 

[English](README.md) | [Русский](README.ru.md)

## Overall description 

`workflow-lib` is a C# library that consists of:
- [Dynamic compilation for C# code](docs/Dynamical/DynamicCompiling.md);
- Configurations: [JSON](docs/Extensions/JsonConfigExtensions.md), XML;
- Databases: [SQLite](docs/DbConnections/SqliteDbConnection.md), [PostgreSQL](docs/DbConnections/PgDbConnection.md), [MySQL](docs/DbConnections/MysqlDbConnection.md), [MS SQL](docs/DbConnections/MssqlDbConnection.md), [Oracle](docs/DbConnections/OracleDbConnection.md);
- Network APIs and operations: 
    - HTTP: [sender](docs/NetworkAPIs/HttpSender.md), [server](docs/NetworkAPIs/HttpServerWF.md), 
    - TCP: [client](docs/NetworkAPIs/TcpClientWF.md), [listener](docs/NetworkAPIs/TcpListenerWF.md), 
    - Email sender: [MimeKit based](docs/NetworkAPIs/EmailSenderMimeKit.md);
- Ethereum: [Nethereum.Web3](docs/NethereumAPI/EthNodeAPIWeb3.md);
- Documents and document related operations (writing, reading, conversion):
    - Common: [attachment](docs/Models/Documents/Attachment.md), [spreadsheet element](docs/Models/Documents/SpreadsheetElement.md), [text document element](docs/Models/Documents/TextDocElement.md).
    - Text-based: [MS Word](docs/DocFormats/TextBased/MSWordConverter.md) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), [TXT](docs/DocFormats/TextBased/TxtConverter.md);
    - Spreadsheets: [MS Excel](docs/DocFormats/Spreadsheets/MSExcelConverter.md) (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
    - [PDF](docs/DocFormats/PdfConverter.md);
    - Images: [PNG](docs/DocFormats/Images/PngConverter.md), [BMP](docs/DocFormats/Images/BmpConverter.md), [JPEG](docs/DocFormats/Images/JpegConverter.md), SVG, GIF, ICO;
    - XML, JSON, OOXML, CSV;
    - HTML, markdown;
    - [Binary](docs/DocFormats/BinaryConverter.md);
- Classes for business:
    - Common: [address](docs/Models/Business/Address.md), [business operation](docs/Models/Business/BusinessOperation.md), [period](docs/Models/Business/Period.md), [risk](docs/Models/Business/Risk.md), etc.
    - Business documents: [bill](docs/Models/Business/BusinessDocuments/Bill.md), [delivery order](docs/Models/Business/BusinessDocuments/DeliveryOrder.md), [employment contract](docs/Models/Business/BusinessDocuments/EmploymentContract.md), etc.
    - Customers: [customer](docs/Models/Business/Customers/Customer.md), [company](docs/Models/Business/Customers/Company.md), [contact](docs/Models/Business/Customers/Contact.md), etc.
    - Information system: [employee](docs/Models/Business/InformationSystem/Employee.md), [user account](docs/Models/Business/InformationSystem/UserAccount.md), [working day](docs/Models/Business/InformationSystem/WorkingDay.md), etc.
    - Monetary: [paycheck](docs/Models/Business/Monetary/Paycheck.md), [payment](docs/Models/Business/Monetary/Payment.md), [pay rate](docs/Models/Business/Monetary/PayRate.md), etc.
    - Products: [product](docs/Models/Business/Products/Product.md), [product category](docs/Models/Business/Products/ProductCategory.md), [project](docs/Models/Business/Products/Project.md).
    - Responsibilities: [employee responsibility](docs/Models/Business/Responsibilities/EmployeeResponsibility.md), [employer responsibility](docs/Models/Business/Responsibilities/EmployerResponsibility.md).
    - Social communication: [message](docs/Models/Business/SocialCommunication/MessageWF.md).
<!--
- Data visualization: Line chart, Bar chart, Histogram, Scatter plot, Box plot, Pareto chart, Pie chart, Area chart, Tree map, Bubble chart, Stripe graphic, Control chart, Run chart, Stem-and-leaf display, Cartogram, Small multiple, Sparkline, Table, Marimekko chart. 
-->

Documentation about namespaces and data types, used in the library, is presented at [this link](docs/documentation.md).

### Goal

The goals of this library are to provide functionalities for dynamic compilation of C# code, operations with databases (SQLite, PostgreSQL, MySQL, MS SQL, Oracle), communication with Ethereum using Nethereum.Web3 library, and operations with documents (MS Word, MS Excel, PDF, images, binary). 

The data models provided in the library are also intended to support business-related functionality.
It includes data models for business-related entities such as common entities, business documents, customers, information system, monetary entities, products, responsibilities, and social communication.

### Scope 

The scope of the project is focused on providing a library of functionalities and data models for use in other applications, rather than a standalone application.

### Who can use this library

Developers working on applications that require the functionalities provided by the library could use this application. 
Companies in industries such as logistics, finance, and document management could potentially benefit from using applications that incorporate this library.

### What projects this library could be used in  

This library could be used in a variety of projects that require dynamic compilation, database operations, communication with Ethereum, and document handling. Examples could include applications for logistics management, financial trading, and document collaboration.

## Technologies 

- Target frameworks:
  - .NET Core 3.1 (C# 8.0)
  - .NET 6 (C# 10)
- [itext7](https://github.com/itext/itext7-dotnet)
- [itext7.pdfhtml](https://github.com/itext/i7n-pdfhtml)
- [Open XML SDK](https://github.com/dotnet/Open-XML-SDK)
- [Open-Xml-PowerTools](https://github.com/alexeysp11/Open-Xml-PowerTools.git)
- [RabbitMQ](https://github.com/rabbitmq/rabbitmq-dotnet-client)
- [MailKit](https://github.com/jstedfast/MailKit) and [MimeKit](https://github.com/jstedfast/MimeKit)
- [Nethereum.Web3](https://github.com/Nethereum/Nethereum/tree/master/src/Nethereum.Web3)

## How to use 

You can use this library in C# code directly:

1. Clone the repository: 
```
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git 
git clone https://github.com/alexeysp11/workflow-lib.git
```

2. Add the reference to the repository in the `csproj` file of your target project: 
```XML
  <ItemGroup>
    <ProjectReference Include="../../workflow-lib/src/Cims.WorkflowLib.csproj" />
  </ItemGroup>
```

<!--
## How to use with XML/JSON wrapper 

You can also use XML/JSON wrapper (kind of no-code approach). 
-->

## How to improve the library   

- [TODO](docs/TODO.md)
