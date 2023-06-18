# PDF converter

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
