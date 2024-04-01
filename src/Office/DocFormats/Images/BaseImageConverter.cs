using System.Linq; 

namespace WorkflowLib.DocFormats.Images 
{
    /// <summary>
    /// Base image converter.
    /// </summary>
    public abstract class BaseImageConverter
    {
        protected void CheckText(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new System.Exception("Text could not be null or empty"); 
        }

        protected void CheckFolderName(string foldername)
        {
            if (!System.IO.Directory.Exists(foldername)) throw new System.Exception("Folder name does not exist"); 
        }

        protected void CheckFileName(string filename, string extension)
        {
            if (string.IsNullOrEmpty(extension)) throw new System.Exception("Desired extension is not specified"); 

            if (string.IsNullOrEmpty(filename)) throw new System.Exception("File name could not be null or empty"); 
            if (filename.Split('.').Last().ToLower() != extension.ToLower()) throw new System.Exception("Incorrect file extension"); 
        }
    }
}