using VelocipedeUtils.Shared.Models.Business.Customers;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;

namespace VelocipedeUtils.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Inquiry.
    /// </summary>
    public class Inquiry : WfBusinessEntity, IWfBusinessEntity, IReceivableBusinessEntity
    {
        /// <summary>
        /// Timestamp when the inquiry was closed.
        /// </summary>
        public DateTime? DateClosed { get; private set; }

        /// <summary>
        /// Date the business entity was received.
        /// </summary>
        public DateTime? DateReceived { get; set; }

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