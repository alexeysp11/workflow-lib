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

## How to use 

### Using in C# code 

You can use this library in C# code directly, for example: 

```C#
using Cims.WorkflowLib; 

public class ExampleClass 
{
    ...
    public void ExampleMethod()
    {
        // 
    }
    ...
}
```

### Using with XML/JSON wrapper 

You can also use XML/JSON wrapper (kind of no-code approach). 
