# MSWordConverter

`MSWordConverter` is a class for using **MS Word** (**MS Word converter**).

Namespace: `Cims.WorkflowLib.DocFormats.TextBased`.

## TextDocElementsToDocument()

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
