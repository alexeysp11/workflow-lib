# workflow-lib 

Read this in other languages: [English](README.md), [Russian/Русский](README.ru.md). 

`workflow-lib` is a C# library that consists of:
- Visual elements for ASP.NET applications (Blazor, Razor Pages, MVC);
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

### Image converter 

Since all the image converters implement `IImageConverter` interface, the following code will be equivalent for all of the image converters from the library: 

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

### PDF converter

You can get PDF file using `PdfConverter` class: 

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

## How to use with XML/JSON wrapper 

You can also use XML/JSON wrapper (kind of no-code approach). 

## How to improve the library   

### Database connections 

- Explain what is the differnece between `DataSource` and `ConnString` in database classes and to use them properly. 
- Create template for using multiple database connections. 
- How to deal with `blob` objects in databases connection classes?
- Method `Cims.WorkflowLib.DbConnections.BaseDbConnection.GetSqlFromDataTable()` does not correct SQL statement, so you need to explain how to use this method properly. 
- How to transfer data from one database to another? 
