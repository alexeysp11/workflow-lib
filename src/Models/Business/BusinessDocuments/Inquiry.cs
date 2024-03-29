using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Inquiry.
    /// </summary>
    public class Inquiry : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Timestamp when the inquiry was received.
        /// </summary>
        public System.DateTime ReceivedAt { get; private set; }

        /// <summary>
        /// Timestamp when the inquiry was closed.
        /// </summary>
        public System.DateTime? ClosedAt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReceivedById { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee ReceivedBy { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Company Customer { get; private set; }

        /// <summary>
        /// List of offers.
        /// </summary>
        public virtual List<Offer> Offers { get; private set; }

        //public virtual List<Attachment> Attachments { get; private set; }

        //public virtual List<InfoRequest> InfoRequests { get; private set; }

        //public virtual List<InquiryEmployee> Assignees { get; private set; }
    }
}