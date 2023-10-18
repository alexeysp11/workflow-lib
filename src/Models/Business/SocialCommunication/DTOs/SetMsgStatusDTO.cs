using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication.DTOs
{
    public class SetMsgStatusDTO : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Status.
        /// </summary>
        public SetMsgStatus Status { get; set; }
    }
}