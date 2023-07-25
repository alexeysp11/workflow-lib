using System.IO; 
using Cims.WorkflowLib.Models.Documents; 

namespace Cims.WorkflowLib.DocFormats.TextBased
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITextBased 
    {
        void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements); 

        System.Collections.Generic.List<TextDocElement> ConvertFileToTde(string foldername, string filename); 
        System.Collections.Generic.List<TextDocElement> ConvertFileToTde(string filepath);
        System.Collections.Generic.List<TextDocElement> ConvertFileToTde(FileInfo file);
        System.Collections.Generic.List<TextDocElement> ConvertStringToTde(string xmlContent);
    }
}