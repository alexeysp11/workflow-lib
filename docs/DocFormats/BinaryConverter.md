# BinaryConverter

`BinaryConverter` is a class for using **binaries** (**binary converter**).

Namespace: [Cims.WorkflowLib.DocFormats](Cims.WorkflowLib.DocFormats.md)

## Methods

### SaveAsBinaryFile()

`BinaryConverter.SaveAsBinaryFile()` saves a byte array as a binary file.

## GetBinaryFile()

`BinaryConverter.GetBinaryFile()` reads all data from a file and gets an array of bytes.

Example of using `BinaryConverter.SaveAsBinaryFile()` and `BinaryConverter.GetBinaryFile()`:

```C#
using System;
using System.IO;
using System.Linq; 
using System.Reflection;
using System.Data; 
using Xunit;
using Cims.WorkflowLib.DocFormats; 
using Cims.WorkflowLib.Models.Documents; 
using Cims.WorkflowLib.Models.Documents.Enums; 

namespace Cims.Tests.WorkflowLib.DocFormats
{
    public class BinaryConverterTest
    {
        private string FolderName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), typeof(BinaryConverterTest).ToString().Split('.').Last()); 

        [Fact]
        public void SaveAsBinaryFile_CorrectParams_FileExists()
        {
            // Arrange
            string filename = System.Reflection.MethodBase.GetCurrentMethod().Name + ".pdf"; 
            string filepath = Path.Combine(FolderName, filename); 
            string binFile = filepath.Replace(".pdf", ".bin"); 
            string copyFile1 = filepath.Replace(".pdf", "_copy_1.pdf"); 
            string copyFile2 = filepath.Replace(".pdf", "_copy_2.pdf"); 
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

            PdfConverter pdfConverter = new PdfConverter(); 
            BinaryConverter binConverter = new BinaryConverter(); 
            CreateFolderIfNotExists(FolderName); 

            // Act
            pdfConverter.TextDocElementsToDocument(FolderName, filename, elements);
            byte[] bytes = binConverter.GetBinaryFile(filepath); 
            binConverter.SaveAsBinaryFile(binFile, bytes); 
            binConverter.SaveAsBinaryFile(copyFile1, bytes); 
            binConverter.SaveAsBinaryFile(copyFile2, binConverter.GetBinaryFile(binFile)); 

            // Assert
            Assert.True(File.Exists(filepath));
            Assert.True(File.Exists(binFile));
            Assert.True(File.Exists(copyFile1));
            Assert.True(File.Exists(copyFile2));
        }

        private void CreateFolderIfNotExists(string foldername)
        {
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername); 
        }
    }
}
```
