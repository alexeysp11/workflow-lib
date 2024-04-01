using WorkflowLib.Models.Documents.Enums; 

namespace WorkflowLib.Models.Documents
{
    /// <summary>
    /// Class for representing an element of spreadsheet document.
    /// </summary>
    public class SpreadsheetElement
    {
        /// <summary>
        /// Cell name.
        /// </summary>
        public string CellName { get; set; }

        /// <summary>
        /// Element of a text document.
        /// </summary>
        public TextDocElement TextDocElement { get; set; }
    }
}