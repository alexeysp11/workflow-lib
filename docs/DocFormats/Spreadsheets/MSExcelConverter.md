# MSExcelConverter Class

Namespace: [Cims.WorkflowLib.DocFormats.Spreadsheets](Cims.WorkflowLib.DocFormats.Spreadsheets.md)

`MSExcelConverter` is a class for using **MS Excel** (**MS Excel converter**).

## Constructors 

### MSExcelConverter()

Default constructor.

```C#
public MSExcelConverter();
```

## Methods

### SpreadsheetElementsToDocument(String, String, UInt32, String, List\<SpreadsheetElement\>)

Method for converting a list of [SpreadsheetElement](../../Models/Documents/SpreadsheetElement.md) into Excel document.

```C#
public void SpreadsheetElementsToDocument(
        string foldername, 
        string filename, 
        uint worksheetId, 
        string worksheetName,
        System.Collections.Generic.List<SpreadsheetElement> elements);
```

#### Parameters 

- `foldername`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Folder name.

- `filename`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

File name (with extension).

- `worksheetId`: [UInt32](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

Worksheet ID.

- `worksheetName`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Worksheet name.

- `elements`: [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<[SpreadsheetElement](../../Models/Documents/SpreadsheetElement.md)>

Collection of [SpreadsheetElement](../../Models/Documents/SpreadsheetElement.md).

#### Examples

Example of using `MSExcelConverter.SpreadsheetElementsToDocument()`:

```C#
using System.IO;
using System.Collections.Generic; 
using Cims.WorkflowLib.DocFormats.Spreadsheets; 
using Cims.WorkflowLib.Models.Documents; 
using Cims.WorkflowLib.Models.Documents.Enums; 

namespace Examples.WorkflowLib
{
    public class MSExcelExample
    {
        ...
        public void UseMSExcelConverter()
        {
            // 
            string filename = "testmsexcel.xlsx"; 
            string foldername = @"C:\PathToMSExcel"; 
            uint worksheetId = 1; 
            string worksheetName = "TestSheet"; 
            var elements = new System.Collections.Generic.List<SpreadsheetElement>()
            {
                new SpreadsheetElement() 
                {
                    CellName = "A1",
                    SpreadsheetElement = new SpreadsheetElement 
                    {
                        Content = "First test header", 
                        FontSize = 14, 
                        TextAlignment = TextAlignment.CENTER
                    }
                }, 
                new SpreadsheetElement() 
                {
                    CellName = "A2",
                    SpreadsheetElement = new SpreadsheetElement 
                    {
                        Content = "Header 2", 
                        FontSize = 14, 
                        TextAlignment = TextAlignment.CENTER
                    }
                }
            }; 

            // 
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername); 
            
            //
            ISpreadsheets converter = new MSExcelConverter(); 
            converter.SpreadsheetElementsToDocument(FolderName, filename, worksheetId, worksheetName, elements);
        }
        ...
    }
}
```
