# Image converter

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
