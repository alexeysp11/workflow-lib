# workflow-lib 

Доступно на других языках: [English/Английский](README.md), [Russian/Русский](README.ru.md). 

`workflow-lib` - это библиотека на C#, состоящая из:
- Визуальных элементов для ASP.NET приложение (Blazor, Razor Pages, MVC); 
- Динамической компиляции кода на C#; 
- Операций с конфигурационными файлами (JSON, XML); 
- Сетевых операций; 
- Операций с базами данных (SQLite, PostgreSQL, MySQL, MS SQL, Oracle); 
- Операций с документами (запись, чтение, конвертация): 
    - Текстовые: MS Word (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), TXT; 
    - Spreadsheets-таблицы: MS Excel (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS); 
    - PDF; 
    - Изображения: PNG, BMP, JPEG, SVG, GIF, ICO; 
    - XML, JSON, OOXML, CSV; 
    - Binary;
- Визуализация данных: Line chart, Bar chart, Histogram, Scatter plot, Box plot, Pareto chart, Pie chart, Area chart, Tree map, Bubble chart, Stripe graphic, Control chart, Run chart, Stem-and-leaf display, Cartogram, Small multiple, Sparkline, Table, Marimekko chart. 

Таким обрзаом, данный репозиторий вполне может быть использован для разработки разного рода клиентских приложений - как коммерческих (ERP, CRM), так и некоммерческих (учебных, open-source). 

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

### Конвертация изображений  

Поскольку все конвертаторы изображений имплементируют общий `IImageConverter` интерфейс, то приведенный ниже код будет эквивалентен для каждого из конвертаторов изображений из данной библиотеки: 

```C#
using System.IO;
using Cims.WorkflowLib.DocFormats.Images; 

namespace Examples.WorkflowLib
{
    public class ImagesExample 
    {
        ...
        public GetPngFromText()
        {
            // 
            string text = "Some text message in png file..."; 
            string filename = "testimage.png"; 
            string foldername = @"C:\PathToImages"; 

            // 
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername); 

            // 
            IImageConverter pngConverter = new PngConverter(); 
            pngConverter.TextToImg(text, foldername, filename);
        }
        ...
    }
}
```

### PDF конвертатор

Для операций над PDF файлом используется класс `PdfConverter`:

```C#
using System.IO;
using System.Collections.Generic; 
using Cims.WorkflowLib.DocFormats; 
using Cims.WorkflowLib.Models.Text; 
using Cims.WorkflowLib.Models.Text.Enums; 

namespace Examples.WorkflowLib
{
    public class PdfExample 
    {
        ...
        public void UsePdfConverter()
        {
            // 
            string filename = "testpdf.pdf"; 
            string foldername = @"C:\PathToPdf"; 
            var elements = new List<TextDocElement>()
            {
                new TextDocElement() 
                {
                    Content = "Header 1", 
                    FontSize = 50, 
                    TextAlignment = TextAlignment.CENTER
                }, 
                new TextDocElement() 
                {
                    Content = "Paragraph 1\nLet's print out some content to the paragraph...", 
                    FontSize = 14, 
                    TextAlignment = TextAlignment.LEFT
                }, 
                new TextDocElement() 
                {
                    Content = "Header 2", 
                    FontSize = 50, 
                    TextAlignment = TextAlignment.CENTER
                }, 
                new TextDocElement() 
                {
                    Content = "Paragraph 2\nLet's print out again some content to the paragraph...", 
                    FontSize = 14, 
                    TextAlignment = TextAlignment.JUSTIFIED
                }
            }; 

            // 
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername); 

            // 
            PdfConverter pdfConverter = new PdfConverter(); 
            pdfConverter.TextDocElementsToDocument(foldername, filename, elements);
        }
        ...
    }
}
```

## Как использовать данную библиотеку совместно с XML/JSON оболочкой  

Подразумевается использование данной библиотеки с помощью XML/JSON оболочки (своего рода no-code подход).

## Как улучшить библиотеку 

### Database connections 

- Explain what is the differnece between `DataSource` and `ConnString` in database classes and to use them properly. 
- Create template for using multiple database connections. 
- How to deal with `blob` objects in databases connection classes?
- Method `Cims.WorkflowLib.DbConnections.BaseDbConnection.GetSqlFromDataTable()` does not correct SQL statement, so you need to explain how to use this method properly. 
- How to transfer data from one database to another? 
