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
        public Employee? ReceivedBy { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CustomerId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Company? CustomerCompany { get; private set; }

        /// <summary>
        /// List of offers.
        /// </summary>
        public List<Offer> Offers { get; private set; }

        //public List<Attachment> Attachments { get; private set; }

        //public List<InfoRequest> InfoRequests { get; private set; }

        //public List<InquiryEmployee> Assignees { get; private set; }
    }
}