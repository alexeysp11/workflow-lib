namespace Cims.WorkflowLib.Models.Documents
{
    /// <summary>
    /// 
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Extention { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UploadDate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] File { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public long Size { get; private set; }
    }
}