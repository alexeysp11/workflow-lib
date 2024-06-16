using System.IO; 
using WorkflowLib.Shared.Models.Documents; 

namespace WorkflowLib.Shared.Office.DocFormats.TextBased
{
    /// <summary>
    /// Interface for using text based documents.
    /// </summary>
    public interface ITextBased 
    {
        /// <summary>
        /// Method for converting a list of TextDocElement into text-based document.
        /// </summary>
        void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements); 

        /// <summary>
        /// Convert WordprocessingML to list of TextDocElement 
        /// </summary>
        System.Collections.Generic.List<TextDocElement> ConvertFileToTde(string foldername, string filename); 
        
        /// <summary>
        /// Convert WordprocessingML to list of TextDocElement 
        /// </summary>
        System.Collections.Generic.List<TextDocElement> ConvertFileToTde(string filepath);
        
        /// <summary>
        /// Convert WordprocessingML to list of TextDocElement 
        /// </summary>
        System.Collections.Generic.List<TextDocElement> ConvertFileToTde(FileInfo file);
        
        /// <summary>
        /// Convert WordprocessingML to list of TextDocElement 
        /// </summary>
        System.Collections.Generic.List<TextDocElement> ConvertStringToTde(string xmlContent);
    }
}