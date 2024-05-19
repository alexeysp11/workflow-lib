using System.Collections.Generic;
using WorkflowLib.Models.Business.Customers;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Inquiry.
    /// </summary>
    public class Inquiry : BusinessEntityWF, IBusinessEntityWF, IReceivableBusinessEntityWF
    {
        /// <summary>
        /// Timestamp when the inquiry was closed.
        /// </summary>
        public System.DateTime? DateClosed { get; private set; }

        /// <summary>
        /// Date the business entity was received.
        /// </summary>
        public System.DateTime? DateReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ReceivedById { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee ReceivedBy { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CustomerId { get; private set; }

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