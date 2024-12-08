using System.IO;
using System.Linq;
using System.Collections.Generic;
using WorkflowLib.Shared.Models.Documents;

namespace WorkflowLib.Shared.Office.DocFormats.TextBased
{
    /// <summary>
    /// Class for using TXT documents 
    /// </summary>
    public class TxtConverter : IWorkflowTextBased
    {
        /// <summary>
        /// Method for converting a list of TextDocElement into TXT document.
        /// </summary>
        public void TextDocElementsToDocument(string foldername, string filename, List<TextDocElement> elements)
        {
            if (!Directory.Exists(foldername))
                throw new System.Exception("Folder name does not exist");
            if (string.IsNullOrEmpty(filename))
                throw new System.Exception("File name could not be null or empty");
            if (filename.Split('.').Last().ToLower() != "txt")
                throw new System.Exception("Incorrect file extension");

            string filepath = Path.Combine(foldername, filename);

            // 
            if (!File.Exists(filepath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    foreach (var element in elements)
                    {
                        sw.WriteLine(element.Content);
                    }
                }
                return;
            }

            // 
            using (StreamWriter sw = File.AppendText(filepath))
            {
                foreach (var element in elements)
                {
                    sw.WriteLine(element.Content);
                }
            }
        }

        #region Convert to list of TextDocElement 
        /// <summary>
        /// Convert to list of TextDocElement 
        /// </summary>
        public List<TextDocElement> ConvertFileToTde(string foldername, string filename)
        {
            if (!Directory.Exists(foldername))
                throw new System.Exception("Folder does not exist");
            if (string.IsNullOrEmpty(filename))
                throw new System.Exception("File name could not be null or empty");

            return ConvertFileToTde(Path.Combine(foldername, filename));
        }

        /// <summary>
        /// Convert to list of TextDocElement 
        /// </summary>
        public List<TextDocElement> ConvertFileToTde(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
                throw new System.Exception("File name could not be null or empty");
            if (!File.Exists(filepath))
                throw new System.Exception("File does not exist");

            return ConvertFileToTde(new FileInfo(filepath));
        }

        /// <summary>
        /// Convert to list of TextDocElement 
        /// </summary>
        public List<TextDocElement> ConvertFileToTde(FileInfo file)
        {
            string content = System.IO.File.ReadAllText(file.FullName);
            if (string.IsNullOrEmpty(content))
                throw new System.Exception("File content could not be empty");

            return ConvertStringToTde(content);
        }

        /// <summary>
        /// Convert to list of TextDocElement 
        /// </summary>
        public List<TextDocElement> ConvertStringToTde(string xmlContent)
        {
            if (string.IsNullOrEmpty(xmlContent))
                throw new System.Exception("XML content could not be empty");

            var elements = new List<TextDocElement>();
            string line = string.Empty;
            StringReader reader = new StringReader(xmlContent);
            while ((line = reader.ReadLine()) != null)
            {
                elements.Add(new TextDocElement() { Content = line });
            };
            
            return elements;
        }
        #endregion  // Convert to list of TextDocElement 
        
        private void CheckCorrectness(string filepath, List<TextDocElement> elements)
        {
            if (string.IsNullOrEmpty(filepath))
                throw new System.Exception("File path could not be null or empty");

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(filepath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    // Console.WriteLine(s);
                }
            }
        }
    }
}