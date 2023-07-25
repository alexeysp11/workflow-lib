using System;
using System.IO;
using System.Linq; 
using System.Reflection;
using System.Data; 
using Xunit;
using Cims.WorkflowLib.DocFormats.Spreadsheets; 
using Cims.WorkflowLib.Models.Documents; 
using Cims.WorkflowLib.Models.Documents.Enums; 

namespace Cims.Tests.WorkflowLib.DocFormats.Spreadsheets
{
    public class MSExcelConverterTest
    {
        private string FolderName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), typeof(MSExcelConverterTest).ToString().Split('.').Last()); 

        [Fact]
        public void SpreadsheetElementsToDocument_CorrectParams_FileExists()
        {
            // Arrange
            string filename = System.Reflection.MethodBase.GetCurrentMethod().Name + ".xlsx"; 
            string filepath = Path.Combine(FolderName, filename); 
            var elements = new System.Collections.Generic.List<SpreadsheetElement>()
            {
                new SpreadsheetElement() 
                {
                    CellName = "A1",
                    TextDocElement = new TextDocElement 
                    {
                        Content = "First test header", 
                        FontSize = 14, 
                        TextAlignment = TextAlignment.CENTER
                    }
                }, 
                new SpreadsheetElement() 
                {
                    CellName = "A2",
                    TextDocElement = new TextDocElement 
                    {
                        Content = "Header 2", 
                        FontSize = 14, 
                        TextAlignment = TextAlignment.CENTER
                    }
                }
            }; 

            ISpreadsheets converter = new MSExcelConverter(); 
            CreateFolderIfNotExists(FolderName); 

            // Act
            converter.SpreadsheetElementsToDocument(FolderName, filename, elements);

            // Assert
            Assert.True(File.Exists(filepath)); 
        }

        #region Private methods
        private void CreateFolderIfNotExists(string foldername)
        {
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername); 
        }
        #endregion  // Private methods
    }
}
