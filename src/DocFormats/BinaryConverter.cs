using System.IO; 

namespace Cims.WorkflowLib.DocFormats
{
    /// <summary>
    /// 
    /// </summary>
    public class BinaryConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public void SaveAsBinaryFile(string filename, byte[] bytes)
        {
            File.WriteAllBytes(filename, bytes); 
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] GetBinaryFile(string filename)
        {
            byte[] bytes;
            using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
            }
            return bytes;
        }
    }
}