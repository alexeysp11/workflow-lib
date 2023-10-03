# JpegConverter

Namespace: [Cims.WorkflowLib.DocFormats.Images](Cims.WorkflowLib.DocFormats.Images.md)

`JpegConverter` is a class for converting text into a **JPEG** image. 

## Constructors 

### JpegConverter()

Default constructor.

```C#
public JpegConverter();
```

## Methods

### TextToImg(String, String, String)

Method for converting text into an image.

```C#
public void TextToImg(string text, string foldername, string filename);
```

#### Parameters 

- `text`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Text to convert.

- `foldername`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Folder name.

- `filename`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

File name (with extension).

#### Examples

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
