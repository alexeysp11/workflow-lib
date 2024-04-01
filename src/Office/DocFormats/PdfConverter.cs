using System.IO; 
using System.Linq; 
using iText.Kernel.Pdf; 
using iText.Layout; 
using iText.Layout.Element; 
using WorkflowLib.Models.Documents; 

namespace WorkflowLib.Office.DocFormats
{
    /// <summary>
    /// Class for using PDF (PDF converter)
    /// </summary>
    public class PdfConverter : WorkflowLib.Office.DocFormats.TextBased.ITextBased
    {
        /// <summary>
        /// Method for converting a list of TextDocElement into TXT document.
        /// </summary>
        public void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements)
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
            catch (System.Exception)
            {
                throw; 
            }
        }

        #region Convert to list of TextDocElement 
        /// <summary>
        /// Convert to list of TextDocElement 
        /// </summary>
        public System.Collections.Generic.List<TextDocElement> ConvertFileToTde(string foldername, string filename)
        {
            if (!Directory.Exists(foldername)) throw new System.Exception("Folder does not exist"); 
            if (string.IsNullOrEmpty(filename)) throw new System.Exception("File name could not be null or empty"); 

            return ConvertFileToTde(Path.Combine(foldername, filename)); 
        }

        /// <summary>
        /// Convert to list of TextDocElement 
        /// </summary>
        public System.Collections.Generic.List<TextDocElement> ConvertFileToTde(string filepath)
        {
            if (string.IsNullOrEmpty(filepath)) throw new System.Exception("File name could not be null or empty"); 
            if (!File.Exists(filepath)) throw new System.Exception("File does not exist"); 

            return ConvertFileToTde(new FileInfo(filepath));
        }

        /// <summary>
        /// Convert to list of TextDocElement 
        /// </summary>
        public System.Collections.Generic.List<TextDocElement> ConvertFileToTde(FileInfo file)
        {
            string content = System.IO.File.ReadAllText(file.FullName); 
            if (string.IsNullOrEmpty(content)) throw new System.Exception("File content could not be empty"); 

            return ConvertStringToTde(content);
        }

        /// <summary>
        /// Convert to list of TextDocElement 
        /// </summary>
        public System.Collections.Generic.List<TextDocElement> ConvertStringToTde(string xmlContent)
        {
            if (string.IsNullOrEmpty(xmlContent)) throw new System.Exception("XML content could not be empty"); 

            // 

            return new System.Collections.Generic.List<TextDocElement>();
        }
        #endregion  // Convert to list of TextDocElement 
    }
}