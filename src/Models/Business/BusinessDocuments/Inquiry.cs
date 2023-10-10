using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    public class Inquiry
    {
        public System.DateTime ReceivedAt { get; private set; }

        public System.DateTime? ClosedAt { get; private set; }

        public string Description { get; private set; }

        public string ReceivedById { get; private set; }

        public string CustomerId { get; private set; }

        public virtual Employee ReceivedBy { get; private set; }

        public virtual Company Customer { get; private set; }

        //public virtual List<Attachment> Attachments { get; private set; }

        //public virtual List<InfoRequest> InfoRequests { get; private set; }

        //public virtual List<InquiryEmployee> Assignees { get; private set; }

        public virtual List<Offer> Offers { get; private set; }
    }
}