using System.IO; 
using Cims.WorkflowLib.Models.Documents; 

namespace Cims.WorkflowLib.DocFormats.Spreadsheets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISpreadsheets 
    {
        void SpreadsheetElementsToDocument(string foldername, string filename, System.Collections.Generic.List<SpreadsheetElement> elements); 

        // System.Collections.Generic.List<SpreadsheetElement> ConvertFileToTde(string foldername, string filename); 
        // System.Collections.Generic.List<SpreadsheetElement> ConvertFileToTde(string filepath);
        // System.Collections.Generic.List<SpreadsheetElement> ConvertFileToTde(FileInfo file);
        // System.Collections.Generic.List<SpreadsheetElement> ConvertStringToTde(string xmlContent);
    }
}