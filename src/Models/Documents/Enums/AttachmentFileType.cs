using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Documents.Enums
{
    /// <summary>
    /// Attachment file type.
    /// </summary>
    public enum AttachmentFileType
    {
        [Display(Name = "Image")]
        Image,
        
        [Display(Name = "Video")]
        Video,
        
        [Display(Name = "PDF")]
        PDF,
        
        [Display(Name = "Text based")]
        TextBased,
        
        [Display(Name = "Spreadsheets")]
        Spreadsheets
    }
}
