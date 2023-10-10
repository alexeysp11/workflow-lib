using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    public class Offer
    {
        public System.DateTime? SentAt { get; private set; }

        public int Revision { get; private set; }

        public System.DateTime? LastRevisedAt { get; private set; }

        public string HtmlContent { get; private set; }

        public bool IsApproved{ get; private set; }

        public bool IsSent{ get; private set; }

        public System.DateTime? ApprovedAt { get; private set; }

        public string InquiryId { get; private set; }

        public string SentById { get; private set; }

        public string CreatedById { get; private set; }

        public string ContractId { get; private set; }

        public virtual Inquiry Inquiry { get; private set; }

        public virtual Employee SentBy { get; private set; }

        public virtual Employee CreatedBy { get; private set; }

        //public virtual CompanyContract Contract { get; private set; }
    }
}