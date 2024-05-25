# Office

[English](README.md) | [Русский](README.ru.md)

Библиотека предлагает операции с документами, поддерживающими несколько форматов, таких как MS word (doc, docx), MS Excel (XLS, XLSX), PDF, изображения (PNG, BMP, JPEG) и бинарные файлы.

Данная часть библиотеки предоставляет базовый функционал для выполнения операций с документами (запись, чтение, конвертация):
- Текстовые: [MS Word](DocFormats/TextBased/MSWordConverter.cs) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), [TXT](DocFormats/TextBased/TxtConverter.cs);
- Spreadsheets-таблицы: [MS Excel](DocFormats/Spreadsheets/MSExcelConverter.cs) (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
- [PDF](DocFormats/PdfConverter.cs);
- Изображения: [PNG](DocFormats/Images/PngConverter.cs), [BMP](DocFormats/Images/BmpConverter.cs), [JPEG](DocFormats/Images/JpegConverter.cs), SVG, GIF, ICO;
- XML, JSON, OOXML, CSV;
- HTML, markdown;
- [Binary](DocFormats/BinaryConverter.cs).

## Технологии 

- Фреймворки .NET:
  - .NET Core 3.1
  - .NET 6
- [itext7](https://github.com/itext/itext7-dotnet)
- [itext7.pdfhtml](https://github.com/itext/i7n-pdfhtml)
- [Open XML SDK](https://github.com/dotnet/Open-XML-SDK)
- [Open-Xml-PowerTools](https://github.com/alexeysp11/Open-Xml-PowerTools.git)

Пожалуйста, обратите внимание, что для использования [Open-Xml-PowerTools](https://github.com/alexeysp11/Open-Xml-PowerTools.git) необходимо выполнить следующую команду в корневой папке ваших проектов:

```
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git
```
