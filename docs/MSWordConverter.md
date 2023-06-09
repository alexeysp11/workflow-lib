# MS Word converter

You can interact with MS Word using `MSWordConverter` class: 

```C#
using System.IO;
using System.Collections.Generic; 
using Cims.WorkflowLib.DocFormats.TextBased; 
using Cims.WorkflowLib.DocFormats.TextBased.Word; 
using Cims.WorkflowLib.Models.Text; 
using Cims.WorkflowLib.Models.Text.Enums; 

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
