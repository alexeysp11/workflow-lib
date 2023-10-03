# PdfConverter

Namespace: [Cims.WorkflowLib.DocFormats](Cims.WorkflowLib.DocFormats.md)

`PdfConverter` is a class for using **PDF** (**PDF converter**).

## Constructors 

### PdfConverter()

Default constructor.

```C#
public PdfConverter();
```

## Methods

### TextDocElementsToDocument(String, String, List\<TextDocElement\>)

Method for converting a list of [TextDocElement](../Models/TextDocElement.md) into TXT document.

```C#
public void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements);
```

#### Parameters 

- `foldername`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Folder name

- `filename`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

File name (with extension)

- `elements`: [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<[TextDocElement](../Models/TextDocElement.md)>

Collection of [TextDocElement](../Models/TextDocElement.md)

#### Examples 

Example of getting PDF file using `PdfConverter.TextDocElementsToDocument()`: 

```C#
using System.IO;
using System.Collections.Generic; 
using Cims.WorkflowLib.DocFormats; 
using Cims.WorkflowLib.Models.Documents; 
using Cims.WorkflowLib.Models.Documents.Enums; 

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
