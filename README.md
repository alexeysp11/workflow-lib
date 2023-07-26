# workflow-lib 

Read this in other languages: [English](README.md), [Russian/Русский](README.ru.md). 

`workflow-lib` is a C# library that consists of:
- Dynamic compilation for C# code; 
- Configurations (JSON, XML); 
- Network: REST API, SOAP, WebAPI; 
- Databases (SQLite, PostgreSQL, MySQL, MS SQL, Oracle);
- Document operations (writing, reading, conversion):
    - Text-based: MS Word (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), TXT;
    - Spreadsheets: MS Excel (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS); 
    - PDF; 
    - Images: PNG, BMP, JPEG, SVG, GIF, ICO; 
    - XML, JSON, OOXML, CSV;
    - HTML, markdown; 
    - Binary;
- Basic monetary operations; 
- Translation; 
- Data visualization: Line chart, Bar chart, Histogram, Scatter plot, Box plot, Pareto chart, Pie chart, Area chart, Tree map, Bubble chart, Stripe graphic, Control chart, Run chart, Stem-and-leaf display, Cartogram, Small multiple, Sparkline, Table, Marimekko chart. 

So this repository could definitely be used for development various types applications - both commercial (ERP, CRM) and non-commercial (studying, open-source). 

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

Examples: 

- [Image converter](docs/ImageConverter.md)
- [PDF converter](docs/PdfConverter.md)
- [MS Word converter](docs/MSWordConverter.md)

## How to use with XML/JSON wrapper 

You can also use XML/JSON wrapper (kind of no-code approach). 

## How to improve the library   

### Database connections 

- Explain what is the differnece between `DataSource` and `ConnString` in database classes and to use them properly. 
- Create template for using multiple database connections. 
- How to deal with `blob` objects in databases connection classes?
- Method `Cims.WorkflowLib.DbConnections.BaseDbConnection.GetSqlFromDataTable()` does not correct SQL statement, so you need to explain how to use this method properly. 
- How to transfer data from one database to another? 
