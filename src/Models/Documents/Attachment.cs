using Cims.WorkflowLib.Models.Documents.Enums;

namespace Cims.WorkflowLib.Models.Documents
{
    /// <summary>
    /// Attachment to the message.
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
        public System.DateTime UploadDate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] File { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public long Size { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public AttachmentFileType FileType { get; private set; }
    }
}