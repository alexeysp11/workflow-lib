using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using OpenXmlPowerTools;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WorkflowLib.Shared.Office.DocFormats.TextBased;

namespace WorkflowLib.Shared.Office.DocFormats.TextBased
{
    /// <summary>
    /// 
    /// </summary>
    public static class MSWordConverterExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static void ConvertToPdf(this MSWordConverter converter, string foldername, string wordFilename, string pdfFilename)
        {
            if (!Directory.Exists(foldername)) throw new System.Exception("Folder does not exist"); 
            if (string.IsNullOrEmpty(wordFilename) || string.IsNullOrEmpty(pdfFilename)) throw new System.Exception("File name could not be null or empty"); 
            if (wordFilename.Split('.').Last().ToLower() != "doc" && wordFilename.Split('.').Last().ToLower() != "docx") throw new System.Exception("Incorrect MS Word extension"); 
            if (pdfFilename.Split('.').Last().ToLower() != "pdf") throw new System.Exception("Incorrect PDF extension"); 

            string wordPath = Path.Combine(foldername, wordFilename); 
            string pdfPath = Path.Combine(foldername, pdfFilename); 
            string htmlPath = pdfPath.Replace(".pdf", ".html"); 
            if (!File.Exists(wordPath)) throw new System.Exception("MS Word file does not exist");

            // Examples of how to use Open-Xml-PowerTools library for getting HTML: 
            // https://github.com/OpenXmlDev/Open-Xml-PowerTools/blob/921cbccf6ecb29456eedc8d4d7834c7bf62c54c9/OpenXmlPowerTools.Tests/HtmlConverterTests.cs
            // https://github.com/itext/i7n-pdfhtml/blob/develop/itext/itext.html2pdf/itext/html2pdf/HtmlConverter.cs
            // Source code of a module that converts WordprocessingML to HTML:
            // https://github.com/OpenXmlDev/Open-Xml-PowerTools/blob/921cbccf6ecb29456eedc8d4d7834c7bf62c54c9/OpenXmlPowerTools/WmlToHtmlConverter.cs
            converter.ConvertToHtml(new FileInfo(wordPath), new FileInfo(htmlPath));
            iText.Html2pdf.HtmlConverter.ConvertToPdf(new FileInfo(htmlPath), new FileInfo(pdfPath)); 
        }

        #region Convert to WordprocessingML and save into XML file
        /// <summary>
        /// 
        /// </summary>
        public static void ConvertToWml(this MSWordConverter converter, string foldername, string wordFilename, string xmlFilename)
        {
            if (!Directory.Exists(foldername)) throw new System.Exception("Folder does not exist"); 
            if (string.IsNullOrEmpty(wordFilename) || string.IsNullOrEmpty(xmlFilename)) throw new System.Exception("File name could not be null or empty"); 
            if (wordFilename.Split('.').Last().ToLower() != "doc" && wordFilename.Split('.').Last().ToLower() != "docx") throw new System.Exception("Incorrect MS Word extension"); 
            if (xmlFilename.Split('.').Last().ToLower() != "xml") throw new System.Exception("Incorrect XML extension"); 

            string wordPath = Path.Combine(foldername, wordFilename); 
            string xmlPath = Path.Combine(foldername, xmlFilename); 

            converter.ConvertToWml(new FileInfo(wordPath), new FileInfo(xmlPath)); 
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ConvertToWml(this MSWordConverter converter, string wordFilename, string xmlFilename)
        {
            if (string.IsNullOrEmpty(wordFilename) || string.IsNullOrEmpty(xmlFilename)) throw new System.Exception("File name could not be null or empty"); 
            if (wordFilename.Split('.').Last().ToLower() != "doc" && wordFilename.Split('.').Last().ToLower() != "docx") throw new System.Exception("Incorrect MS Word extension"); 
            if (xmlFilename.Split('.').Last().ToLower() != "xml") throw new System.Exception("Incorrect XML extension"); 

            converter.ConvertToWml(new FileInfo(wordFilename), new FileInfo(xmlFilename)); 
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static void ConvertToWml(this MSWordConverter converter, FileInfo sourceDocx, FileInfo destFileName)
        {
            byte[] byteArray = File.ReadAllBytes(sourceDocx.FullName);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wDoc = WordprocessingDocument.Open(memoryStream, true))
                {
                    wDoc.MainDocumentPart.GetXDocument().Save(destFileName.FullName); 
                }
            }
        }
        #endregion  // Convert to WordprocessingML and save into XML file

        #region Convert to HTML 
        /// <summary>
        /// Convert to HTML.
        /// </summary>
        public static void ConvertToHtml(this MSWordConverter converter, string foldername, string wordFilename, string htmlFilename)
        {
            if (!Directory.Exists(foldername)) throw new System.Exception("Folder does not exist"); 
            if (string.IsNullOrEmpty(wordFilename) || string.IsNullOrEmpty(htmlFilename)) throw new System.Exception("File name could not be null or empty"); 
            if (wordFilename.Split('.').Last().ToLower() != "doc" && wordFilename.Split('.').Last().ToLower() != "docx") throw new System.Exception("Incorrect MS Word extension"); 
            if (htmlFilename.Split('.').Last().ToLower() != "html") throw new System.Exception("Incorrect HTML extension"); 

            string wordPath = Path.Combine(foldername, wordFilename); 
            string htmlPath = Path.Combine(foldername, htmlFilename); 

            converter.ConvertToHtml(new FileInfo(wordPath), new FileInfo(htmlPath)); 
        }

        /// <summary>
        /// Convert MS to HTML.
        /// </summary>
        public static void ConvertToHtml(this MSWordConverter converter, string wordFilename, string htmlFilename)
        {
            if (string.IsNullOrEmpty(wordFilename) || string.IsNullOrEmpty(htmlFilename)) throw new System.Exception("File name could not be null or empty"); 
            if (wordFilename.Split('.').Last().ToLower() != "doc" && wordFilename.Split('.').Last().ToLower() != "docx") throw new System.Exception("Incorrect MS Word extension"); 
            if (htmlFilename.Split('.').Last().ToLower() != "html") throw new System.Exception("Incorrect HTML extension"); 

            converter.ConvertToHtml(new FileInfo(wordFilename), new FileInfo(htmlFilename)); 
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static void ConvertToHtml(this MSWordConverter converter, FileInfo sourceDocx, FileInfo destFileName)
        {
            byte[] byteArray = File.ReadAllBytes(sourceDocx.FullName);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wDoc = WordprocessingDocument.Open(memoryStream, true))
                {
                    var outputDirectory = destFileName.Directory;
                    destFileName = new FileInfo(Path.Combine(outputDirectory.FullName, destFileName.Name));
                    var imageDirectoryName = destFileName.FullName.Substring(0, destFileName.FullName.Length - 5) + "_files";
                    var pageTitle = (string)wDoc.CoreFilePropertiesPart.GetXDocument().Descendants(DC.title).FirstOrDefault();
                    if (pageTitle == null)
                        pageTitle = sourceDocx.FullName;

                    WmlToHtmlConverterSettings settings = new WmlToHtmlConverterSettings()
                    {
                        PageTitle = pageTitle,
                        FabricateCssClasses = true,
                        CssClassPrefix = "pt-",
                        RestrictToSupportedLanguages = false,
                        RestrictToSupportedNumberingFormats = false
                    };
                    XElement html = WmlToHtmlConverter.ConvertToHtml(wDoc, settings);

                    // Note: the xhtml returned by ConvertToHtmlTransform contains objects of type
                    // XEntity.  PtOpenXmlUtil.cs define the XEntity class.  See
                    // http://blogs.msdn.com/ericwhite/archive/2010/01/21/writing-entity-references-using-linq-to-xml.aspx
                    // for detailed explanation.
                    //
                    // If you further transform the XML tree returned by ConvertToHtmlTransform, you
                    // must do it correctly, or entities will not be serialized properly.

                    var htmlString = html.ToString(SaveOptions.DisableFormatting);
                    File.WriteAllText(destFileName.FullName, htmlString, System.Text.Encoding.UTF8);
                }
            }
        }
        #endregion  // Convert to HTML 
    }
}
