using System.IO; 
using System.Linq; 
using DocumentFormat.OpenXml.Packaging; 
using DocumentFormat.OpenXml.Wordprocessing; 
using Cims.WorkflowLib.Models.Text; 
using Cims.WorkflowLib.DocFormats.TextBased; 

namespace Cims.WorkflowLib.DocFormats.TextBased.Word
{
    /// <summary>
    /// 
    /// </summary>
    public class MSWordConverter : ITextBased 
    {
        public void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements)
        {
            if (!Directory.Exists(foldername)) throw new System.Exception("Folder name does not exist"); 
            if (string.IsNullOrEmpty(filename)) throw new System.Exception("File name could not be null or empty"); 
            if (filename.Split('.').Last().ToLower() != "doc" && filename.Split('.').Last().ToLower() != "docx") throw new System.Exception("Incorrect file extension"); 

            string filepath = Path.Combine(foldername, filename); 
            if (!File.Exists(foldername)) using (FileStream fs = File.Create(filepath)); 
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filepath, true))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document(); 
                mainPart.Document.Body = new Body(); 
                foreach (var element in elements)
                {
                    // TODO: Add alignment and font properties!
                    Paragraph paragraph = new Paragraph(); 
                    Run run = new Run(new Text(element.Content)); 
                    paragraph.Append(run); 
                    mainPart.Document.Body.Append(paragraph); 
                    mainPart.Document.Save(); 
                }
            }
        }
    }
}