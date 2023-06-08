using Cims.WorkflowLib.Models.Text; 

namespace Cims.WorkflowLib.DocFormats.TextBased
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITextBased 
    {
        void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements); 
    }
}