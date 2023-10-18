using Cims.WorkflowLib.Models.Documents.Enums;

namespace Cims.WorkflowLib.Models.Documents
{
    /// <summary>
    /// Attachment to the message.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// File name.
        /// </summary>
        public string FileName { get; private set; }
        
        /// <summary>
        /// Extention.
        /// </summary>
        public string Extention { get; private set; }

        /// <summary>
        /// Upload date.
        /// </summary>
        public System.DateTime UploadDate { get; private set; }

        /// <summary>
        /// File.
        /// </summary>
        public byte[] File { get; private set; }

        /// <summary>
        /// Size.
        /// </summary>
        public long Size { get; private set; }

        /// <summary>
        /// File type.
        /// </summary>
        public AttachmentFileType FileType { get; private set; }
    }
}