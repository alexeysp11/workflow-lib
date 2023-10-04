# PngConverter Class

Namespace: [Cims.WorkflowLib.DocFormats.Images](Cims.WorkflowLib.DocFormats.Images.md)

`PngConverter` is a class for converting text into a **PNG** image. 

## Constructors 

### PngConverter()

Default constructor.

```C#
public PngConverter();
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

Example of using `PngConverter.TextToImg()`. 
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
            IImageConverter imgConverter = new PngConverter();
            imgConverter.TextToImg(text, foldername, filename);
        }
        ...
    }
}
```
