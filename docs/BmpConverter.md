# BmpConverter

`BmpConverter` is a class for converting text into a **BMP** image. 

Namespace: `Cims.WorkflowLib.DocFormats.Images`.

## TextToImg()

Example of using `BmpConverter.TextToImg()`. 
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
            string text = "Some text message in bmp file...";
            string filename = "testimage.bmp";
            string foldername = @"C:\PathToImages";

            // 
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername);

            // 
            IImageConverter imgConverter = new BmpConverter();
            imgConverter.TextToImg(text, foldername, filename);
        }
        ...
    }
}
```
