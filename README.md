# workflow-lib 

`workflow-lib` is a C# library that consists of:
- visual elements for WPF and ASP.NET applications (Blazor, Razor Pages, MVC);
- Configurations (JSON, XML); 
- Network; 
- Databases (SQLite, PostgreSQL, MySQL, MS SQL, Oracle);
- Document operations (writing, reading, conversion):
    - Text-based: MS Word (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), TXT;
    - Spreadsheets: MS Excel (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS); 
    - PDF; 
    - Images: PNG, BMP, JPG, JPEG, SVG, GIF; 
    - XML, JSON, OOXML, CSV; 
    - Binary. 

This repository could be used for development applications. 

## How to use in C# code 

You can use this library in C# code directly:

1. Clone the repository (suppose that the `csproj` file of your project is located in the folder `C:\PathToProj\your-project`): 
```
cd ..
git clone https://github.com/alexeysp11/workflow-lib.git
cd your-project
```

2. Add the reference to the repository: 
```XML
  <ItemGroup>
    <ProjectReference Include="../../workflow-lib/src/Cims.WorkflowLib.csproj" />
  </ItemGroup>
```

### Image converter 

Since all the image converters implement `IImageConverter` interface, the following code will be equivalent for all of them: 

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
            pdfConverter.TextDocElementsToPdf(foldername, filename, elements);
        }
        ...
    }
}
```

## How to use with XML/JSON wrapper 

You can also use XML/JSON wrapper (kind of no-code approach). 

## How to improve the application  

- Explain what is the differnece between `DataSource` and `ConnString` in database classes and to use them properly. 
