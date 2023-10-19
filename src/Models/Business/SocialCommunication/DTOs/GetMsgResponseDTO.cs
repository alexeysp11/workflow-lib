using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.SocialCommunication;
using Cims.WorkflowLib.Models.ErrorHandling;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class GetMsgResponseDTO
    {
        /// <summary>
        /// Messages.
        /// </summary>
        public ICollection<MessageWF> Messages { get; set; }

        /// <summary>
        /// Spevifies if the oldest message is included.
        /// </summary>
        public bool IsOldestMsgIncluded { get; set; }

        /// <summary>
        /// Thrown exception.
        /// </summary>
        public WorkflowException WorkflowException { get; set; }
    }
}