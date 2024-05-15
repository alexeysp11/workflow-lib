using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Offer.
    /// </summary>
    public class Offer : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DateSent { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Revision { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? LastRevisedAt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string? HtmlContent { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsApproved{ get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSent{ get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? ApprovedAt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string? InquiryId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string? SentById { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CreatedById { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ContractId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Inquiry Inquiry { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee SentBy { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee CreatedBy { get; private set; }

        //public virtual CompanyContract Contract { get; private set; }
    }
}