# Office

[English](README.md) | [Русский](README.ru.md)

The library offers operations with documents, supporting multiple formats such as MS word (doc, docx), MS Excel (XLS, XLSX), PDF, images (PNG, BMP, JPEG), and binary files.

This part of the library provides basic functionality for performing operations with documents (writing, reading, converting):
- Text-based: [MS Word](DocFormats/TextBased/MSWordConverter.cs) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), [TXT](DocFormats/TextBased/TxtConverter.cs);
- Spreadsheets: [MS Excel](DocFormats/Spreadsheets/MSExcelConverter.cs) (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
- [PDF](DocFormats/PdfConverter.cs);
- Images: [PNG](DocFormats/Images/PngConverter.cs), [BMP](DocFormats/Images/BmpConverter.cs), [JPEG](DocFormats/Images/JpegConverter.cs), SVG, GIF, ICO;
- XML, JSON, OOXML, CSV;
- HTML, markdown;
- [Binary](DocFormats/BinaryConverter.cs);

## Technologies 

- Target frameworks:
  - .NET Core 3.1
  - .NET 6
- [itext7](https://github.com/itext/itext7-dotnet)
- [itext7.pdfhtml](https://github.com/itext/i7n-pdfhtml)
- [Open XML SDK](https://github.com/dotnet/Open-XML-SDK)
- [Open-Xml-PowerTools](https://github.com/alexeysp11/Open-Xml-PowerTools.git)

Please note that to use [Open-Xml-PowerTools](https://github.com/alexeysp11/Open-Xml-PowerTools.git) you must run the following command in the root folder of your projects:

```
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git
```
