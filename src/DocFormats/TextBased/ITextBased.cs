using System.IO; 
using Cims.WorkflowLib.Models.Documents; 

namespace Cims.WorkflowLib.DocFormats.TextBased
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