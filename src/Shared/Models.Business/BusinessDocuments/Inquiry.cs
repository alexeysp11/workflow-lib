using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Inquiry.
    /// </summary>
    public class Inquiry : WfBusinessEntity, IWfBusinessEntity, IReceivableBusinessEntity
    {
        /// <summary>
        /// Timestamp when the inquiry was closed.
        /// </summary>
        public DateTime? DateClosed { get; set; }

        /// <summary>
        /// Date the business entity was received.
        /// </summary>
        public DateTime? DateReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ReceivedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee? ReceivedBy { get; set; }

        /// <summary>
        /// Customer ID.
        /// </summary>
        public string? CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Company? CustomerCompany { get; set; }

        //public List<Attachment> Attachments { get; set; }

        //public List<InfoRequest> InfoRequests { get; set; }

        //public List<InquiryEmployee> Assignees { get; set; }
    }
}