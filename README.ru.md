# workflow-lib 

Доступно на других языках: [English/Английский](README.md), [Russian/Русский](README.ru.md). 

`workflow-lib` - это библиотека на C#, состоящая из:
- [Динамической компиляции кода на C#](docs/Dynamical/DynamicCompiling.md);
- Конфигурационные файлы (JSON, XML);
- Базы данных: [SQLite](docs/DbConnections/SqliteDbConnection.md), [PostgreSQL](docs/DbConnections/PgDbConnection.md), [MySQL](docs/DbConnections/MysqlDbConnection.md), [MS SQL](docs/DbConnections/MssqlDbConnection.md), [Oracle](docs/DbConnections/OracleDbConnection.md);
- Сетевое взаимодействие: [HTTP](docs/NetworkApis/HttpSender.md);
- Операций с документами (запись, чтение, конвертация): 
    - Текстовые: [MS Word](docs/DocFormats/TextBased/MSWordConverter.md) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), [TXT](docs/DocFormats/TextBased/TxtConverter.md);
    - Spreadsheets-таблицы: [MS Excel](docs/DocFormats/Spreadsheets/MSExcelConverter.md) (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
    - [PDF](docs/DocFormats/PdfConverter.md);
    - Изображения: [PNG](docs/DocFormats/Images/PngConverter.md), [BMP](docs/DocFormats/Images/BmpConverter.md), [JPEG](docs/DocFormats/Images/JpegConverter.md), SVG, GIF, ICO;
    - XML, JSON, OOXML, CSV;
    - [Binary](docs/DocFormats/BinaryConverter.md);
- Базовые денежные модели (классы) и операции;
- Визуализация данных: Line chart, Bar chart, Histogram, Scatter plot, Box plot, Pareto chart, Pie chart, Area chart, Tree map, Bubble chart, Stripe graphic, Control chart, Run chart, Stem-and-leaf display, Cartogram, Small multiple, Sparkline, Table, Marimekko chart. 

## Как использовать библиотеку в C# коде 

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

## Как использовать данную библиотеку совместно с XML/JSON оболочкой  

Подразумевается использование данной библиотеки с помощью XML/JSON оболочки (своего рода no-code подход).

## Как улучшить библиотеку 

[Кликните здесь](docs/TODO.md) для того, чтобы прочитать информацию о том, как можно улучшить данную библиотеку. 
