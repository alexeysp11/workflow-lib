using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class SendMsgStatusDTO : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Status.
        /// </summary>
        public SendMsgStatus Status { get; set; }
    }
}