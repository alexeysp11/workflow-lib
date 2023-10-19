using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Comment.
    /// </summary>
    public class Comment : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public System.DateTime CreationDate { get; set; }

        /// <summary>
        /// Creation author.
        /// </summary>
        public UserAccount CreationAuthor { get; set; }
    }
}