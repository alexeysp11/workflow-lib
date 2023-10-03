# JpegConverter

`JpegConverter` is a class for converting text into a **JPEG** image. 

Namespace: [Cims.WorkflowLib.DocFormats.Images](Cims.WorkflowLib.DocFormats.Images.md)

## TextToImg()

Example of using `JpegConverter.TextToImg()`. 
Since all the image imgConverters implement `IImageConverter` interface, the following code will be equivalent for all of the image imgConverters from the library:

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
            string text = "Some text message in jpeg file...";
            string filename = "testimage.jpeg";
            string foldername = @"C:\PathToImages";

            // 
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername);

            // 
            IImageConverter imgConverter = new JpegConverter();
            imgConverter.TextToImg(text, foldername, filename);
        }
        ...
    }
}
```
