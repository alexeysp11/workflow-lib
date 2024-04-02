# Office

[English](README.md) | [Русский](README.ru.md)

Данная часть библиотеки предоставляет базовый функционал для выполнения операций с документами (запись, чтение, конвертация):
- Текстовые: [MS Word](DocFormats/TextBased/MSWordConverter.cs) (DOC, DOT, DOCX, DOTX, DOCM, DOTM), OpenDocument (ODT, FODT, OTT), [TXT](DocFormats/TextBased/TxtConverter.cs);
- Spreadsheets-таблицы: [MS Excel](DocFormats/Spreadsheets/MSExcelConverter.cs) (XLS, XLT, XLW, XLSX, XLTX, XLSM, XLTM), OpenDocument (ODS, FODS, OTS);
- [PDF](DocFormats/PdfConverter.cs);
- Изображения: [PNG](DocFormats/Images/PngConverter.cs), [BMP](DocFormats/Images/BmpConverter.cs), [JPEG](DocFormats/Images/JpegConverter.cs), SVG, GIF, ICO;
- XML, JSON, OOXML, CSV;
- HTML, markdown;
- [Binary](DocFormats/BinaryConverter.cs).
