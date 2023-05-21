using System.IO; 
using System.Linq; 
using iText.Kernel.Pdf; 
using iText.Layout; 
using iText.Layout.Element; 
using Cims.WorkflowLib.Models.Text; 

namespace Cims.WorkflowLib.DocFormats
{
    /// <summary>
    /// 
    /// </summary>
    public class PdfConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public void TextDocElementsToPdf(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements)
        {
            if (!Directory.Exists(foldername)) throw new System.Exception("Folder name does not exist"); 
            if (string.IsNullOrEmpty(filename)) throw new System.Exception("File name could not be null or empty"); 
            if (filename.Split('.').Last().ToLower() != "pdf") throw new System.Exception("Incorrect file extension"); 

            // TODO: Check if the following piece of code catches all the possible exceptions! 
            try
            {
                string filepath = Path.Combine(foldername, filename); 
                using (var writer = new PdfWriter(filepath))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document doc = new Document(pdf))
                {
                    foreach (var element in elements)
                    {
                        Paragraph paragraph = new Paragraph(element.Content)
                            .SetTextAlignment((iText.Layout.Properties.TextAlignment)element.TextAlignment)
                            .SetFontSize(element.FontSize); 
                        doc.Add(paragraph); 
                    }
                    doc.Close(); 
                }
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
        }
    }
}