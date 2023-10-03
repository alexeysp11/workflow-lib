# workflow-lib 

Read this in other languages: [English](README.md), [Russian/Русский](README.ru.md). 

`workflow-lib` is a C# library that consists of:
- [Dynamic compilation for C# code](docs/Dynamical/DynamicCompiling.md);
- Configurations (JSON, XML);
- Databases: [SQLite](docs/DbConnections/SqliteDbConnection.md), [PostgreSQL](docs/DbConnections/PgDbConnection.md), [MySQL](docs/DbConnections/MysqlDbConnection.md), [MS SQL](docs/DbConnections/MssqlDbConnection.md), [Oracle](docs/DbConnections/OracleDbConnection.md);
- Network operations: [HTTP](docs/NetworkApis/HttpSender.md);
- Document operations (writing, reading, conversion):
    - Text-based: [MS Word](docs/DocFormats/TextBased/MSWordConverter.md) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), TXT;
    - Spreadsheets: [MS Excel](docs/DocFormats/Spreadsheets/MSExcelConverter.md) (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
    - [PDF](docs/DocFormats/PdfConverter.md);
    - Images: [PNG](docs/DocFormats/Images/PngConverter.md), [BMP](docs/DocFormats/Images/BmpConverter.md), [JPEG](docs/DocFormats/Images/JpegConverter.md), SVG, GIF, ICO;
    - XML, JSON, OOXML, CSV;
    - HTML, markdown;
    - [Binary](docs/DocFormats/BinaryConverter.md);
- Basic monetary models (classes) and operations;
- Data visualization: Line chart, Bar chart, Histogram, Scatter plot, Box plot, Pareto chart, Pie chart, Area chart, Tree map, Bubble chart, Stripe graphic, Control chart, Run chart, Stem-and-leaf display, Cartogram, Small multiple, Sparkline, Table, Marimekko chart. 

## How to use this library in C# code 

You can use this library in C# code directly:

1. Clone the repository (suppose that the `csproj` file of your target project is located in the folder `C:\PathToProj\your-project`): 
```
cd C:\PathToProj\your-project
cd ..
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git 
git clone https://github.com/alexeysp11/workflow-lib.git
cd your-project
```

2. Add the reference to the repository in the `csproj` file of your target project: 
```XML
  <ItemGroup>
    <ProjectReference Include="../../workflow-lib/src/Cims.WorkflowLib.csproj" />
  </ItemGroup>
```

## How to use with XML/JSON wrapper 

You can also use XML/JSON wrapper (kind of no-code approach). 

## How to improve the library   

[Click here](docs/TODO.md) to read info on how to improve this library. 
