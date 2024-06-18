using System.IO;
using System.Collections.Generic;
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
        void TextDocElementsToDocument(string foldername, string filename, List<TextDocElement> elements);
    }
}