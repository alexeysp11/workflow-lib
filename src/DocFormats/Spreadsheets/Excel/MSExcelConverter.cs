using System.IO; 
using System.Linq; 
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Cims.WorkflowLib.Models.Text; 

namespace Cims.WorkflowLib.DocFormats.Spreadsheets.Excel
{
    /// <summary>
    /// 
    /// </summary>
    public class MSExcelConverter : Cims.WorkflowLib.DocFormats.Spreadsheets.ISpreadsheets
    {
        /// <summary>
        /// 
        /// </summary>
        public void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements)
        {
            if (!Directory.Exists(foldername)) throw new System.Exception("Folder does not exist"); 
            if (string.IsNullOrEmpty(filename)) throw new System.Exception("File name could not be null or empty"); 
            if (filename.Split('.').Last().ToLower() != "xls" && filename.Split('.').Last().ToLower() != "xlsx") throw new System.Exception("Incorrect file extension"); 

            // Read: 
            // https://learn.microsoft.com/en-us/office/open-xml/how-to-calculate-the-sum-of-a-range-of-cells-in-a-spreadsheet-document
            // 
            string filepath = Path.Combine(foldername, filename); 
            if (!File.Exists(foldername)) using (FileStream fs = File.Create(filepath)); 
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filepath, true);

            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet() 
            { 
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), 
                SheetId = 1, 
                Name = "mySheet" 
            };
            sheets.Append(sheet);

            workbookpart.Workbook.Save();

            // Close the document.
            spreadsheetDocument.Close();
        }
    }
}