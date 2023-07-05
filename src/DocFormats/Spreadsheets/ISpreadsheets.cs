using System.IO; 
using Cims.WorkflowLib.Models.Text; 

namespace Cims.WorkflowLib.DocFormats.Spreadsheets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISpreadsheets 
    {
        void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements); 

        // System.Collections.Generic.List<TextDocElement> ConvertFileToTde(string foldername, string filename); 
        // System.Collections.Generic.List<TextDocElement> ConvertFileToTde(string filepath);
        // System.Collections.Generic.List<TextDocElement> ConvertFileToTde(FileInfo file);
        // System.Collections.Generic.List<TextDocElement> ConvertStringToTde(string xmlContent);
    }
}