# MSExcelConverter

`MSExcelConverter` is a class for using **MS Excel** (**MS Excel converter**).

Namespace: [Cims.WorkflowLib.DocFormats.Spreadsheets](Cims.WorkflowLib.DocFormats.Spreadsheets.md)

## Methods

### SpreadsheetElementsToDocument()

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
                    TextDocElement = new TextDocElement 
                    {
                        Content = "First test header", 
                        FontSize = 14, 
                        TextAlignment = TextAlignment.CENTER
                    }
                }, 
                new SpreadsheetElement() 
                {
                    CellName = "A2",
                    TextDocElement = new TextDocElement 
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
