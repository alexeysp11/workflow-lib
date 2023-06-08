using System.IO; 
using System.Linq; 
using Cims.WorkflowLib.Models.Text; 

namespace Cims.WorkflowLib.DocFormats.TextBased
{
    /// <summary>
    /// 
    /// </summary>
    public class TxtConverter : ITextBased
    {
        /// <summary>
        /// 
        /// </summary>
        public void TextDocElementsToDocument(string foldername, string filename, System.Collections.Generic.List<TextDocElement> elements)
        {
            if (!Directory.Exists(foldername)) throw new System.Exception("Folder name does not exist"); 
            if (string.IsNullOrEmpty(filename)) throw new System.Exception("File name could not be null or empty"); 
            if (filename.Split('.').Last().ToLower() != "txt") throw new System.Exception("Incorrect file extension"); 

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
        
        private void CheckCorrectness(string filepath, System.Collections.Generic.List<TextDocElement> elements)
        {
            if (string.IsNullOrEmpty(filepath)) throw new System.Exception("File path could not be null or empty"); 

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