using System.Collections.Generic;
using System.IO; 
using System.Linq; 
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Given a document name, a worksheet name, the name of the first cell in the contiguous range, 
        /// the name of the last cell in the contiguous range, and the name of the results cell, 
        /// calculates the sum of the cells in the contiguous range and inserts the result into the results cell.
        /// Note: All cells in the contiguous range must contain numbers.
        /// </summary>
        public void CalculateSumOfCellRange(string docName, string worksheetName, string firstCellName, string lastCellName, string resultCell)
        {
            // Open the document for editing.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(docName, true))
            {
                IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == worksheetName);
                if (sheets.Count() == 0)
                {
                    // The specified worksheet does not exist.
                    return; 
                }

                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheets.First().Id);
                Worksheet worksheet = worksheetPart.Worksheet;

                // Get the row number and column name for the first and last cells in the range.
                uint firstRowNum = GetRowIndex(firstCellName);
                uint lastRowNum = GetRowIndex(lastCellName);
                string firstColumn = GetColumnName(firstCellName);
                string lastColumn = GetColumnName(lastCellName);

                double sum = 0;

                // Iterate through the cells within the range and add their values to the sum.
                foreach (Row row in worksheet.Descendants<Row>().Where(r => r.RowIndex.Value >= firstRowNum && r.RowIndex.Value <= lastRowNum))
                {
                    foreach (Cell cell in row)
                    {
                        string columnName = GetColumnName(cell.CellReference.Value);
                        if (CompareColumn(columnName, firstColumn) >= 0 && CompareColumn(columnName, lastColumn) <= 0)
                        {
                            sum += double.Parse(cell.CellValue.Text);
                        }
                    }
                }

                // Get the SharedStringTablePart and add the result to it.
                // If the SharedStringPart does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (document.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = document.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = document.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the result into the SharedStringTablePart.
                int index = InsertSharedStringItem("Result:" + sum, shareStringPart);

                Cell result = InsertCellInWorksheet(GetColumnName(resultCell), GetRowIndex(resultCell), worksheetPart);

                // Set the value of the cell.
                result.CellValue = new CellValue(index.ToString());
                result.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                worksheetPart.Worksheet.Save();
            }
        }

        /// <summary>
        /// Given a cell name, parses the specified cell to get the row index.
        /// </summary>
        private uint GetRowIndex(string cellName)
        {
            // Create a regular expression to match the row index portion the cell name.
            return uint.Parse(new Regex(@"\d+").Match(cellName).Value);
        }

        /// <summary>
        /// Given a cell name, parses the specified cell to get the column name.
        /// </summary>
        private string GetColumnName(string cellName)
        {
            // Create a regular expression to match the column name portion of the cell name.
            return new Regex("[A-Za-z]+").Match(cellName).Value;
        }

        /// <summary>
        /// Given two columns, compares the columns.
        /// </summary>
        private int CompareColumn(string column1, string column2)
        {
            if (column1.Length > column2.Length)
            {
                return 1;
            }
            else if (column1.Length < column2.Length)
            {
                return -1;
            }
            else
            {
                return string.Compare(column1, column2, true);
            }
        }

        /// <summary>
        /// Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text 
        /// and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        /// </summary>
        private int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create it.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    // The text already exists in the part. Return its index.
                    return i;
                }
                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        /// <summary>
        /// Given a column name, a row index, and a WorksheetPart, inserts a cell into the worksheet. 
        /// If the cell already exists, returns it. 
        /// </summary>
        private Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }
    }
}