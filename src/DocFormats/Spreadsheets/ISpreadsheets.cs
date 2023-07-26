using System.IO; 
using Cims.WorkflowLib.Models.Documents; 

namespace Cims.WorkflowLib.DocFormats.Spreadsheets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISpreadsheets 
    {
        void SpreadsheetElementsToDocument(
            string foldername, 
            string filename, 
            string worksheetName, 
            System.Collections.Generic.List<SpreadsheetElement> elements); 
        void CalculateSumOfCellRange(
            string docName, 
            string worksheetName, 
            string firstCellName, 
            string lastCellName, 
            string resultCell); 
    }
}