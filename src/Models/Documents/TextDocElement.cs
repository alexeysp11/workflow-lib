using Cims.WorkflowLib.Models.Documents.Enums; 

namespace Cims.WorkflowLib.Models.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public class TextDocElement
    {
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TextAlignment TextAlignment { get; set; }
    }
}