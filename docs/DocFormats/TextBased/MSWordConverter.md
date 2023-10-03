# MSWordConverter

Namespace: [Cims.WorkflowLib.DocFormats.TextBased](Cims.WorkflowLib.DocFormats.TextBased.md)

`MSWordConverter` is a class for using **MS Word** (**MS Word converter**).

## Constructors 

### MSWordConverter()

Default constructor.

```C#
public MSWordConverter();
```

## Methods

### TextDocElementsToDocument(String, String, List\<TextDocElement\>)

```C#
public void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements);
```

#### Parameters 

- `foldername`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Folder name

- `filename`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

File name (with extension)

- `elements`: [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[TextDocElement](../../Models/TextDocElement.md)\>

Collection of [TextDocElement](../../Models/TextDocElement.md)

#### Examples 

Example of interacting with MS Word using `MSWordConverter.TextDocElementsToDocument()`: 

```C#
using System.IO;
using System.Collections.Generic; 
using Cims.WorkflowLib.DocFormats.TextBased; 
using Cims.WorkflowLib.Models.Documents; 
using Cims.WorkflowLib.Models.Documents.Enums; 

namespace Examples.WorkflowLib
{
    public class MSWordExample 
    {
        ...
        public void UseMSWordConverter()
        {
            // 
            string filename = "testmsword.doc"; 
            string foldername = @"C:\PathToMSWord"; 
            var elements = new System.Collections.Generic.List<TextDocElement>()
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
            ITextBased converter = new MSWordConverter(); 
            converter.TextDocElementsToDocument(foldername, filename, elements);
        }
        ...
    }
}
```
