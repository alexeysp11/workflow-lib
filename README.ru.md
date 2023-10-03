# workflow-lib 

Доступно на других языках: [English/Английский](README.md), [Russian/Русский](README.ru.md). 

`workflow-lib` - это библиотека на C#, состоящая из:
- Динамической компиляции кода на C#;
- Конфигурационные файлы (JSON, XML);
- Базы данных (SQLite, PostgreSQL, MySQL, MS SQL, Oracle);
- Сетевое взаимодействие: [HTTP](docs/HttpSender.md);
- Операций с документами (запись, чтение, конвертация): 
    - Текстовые: [MS Word](docs/MSWordConverter.md) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), TXT;
    - Spreadsheets-таблицы: MS Excel (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
    - [PDF](docs/PdfConverter.md);
    - Изображения: [PNG](docs/PngConverter.md), [BMP](docs/BmpConverter.md), [JPEG](docs/JpegConverter.md), SVG, GIF, ICO;
    - XML, JSON, OOXML, CSV;
    - Binary;
- Базовые денежные операции;
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
