namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    public class OfferInquiry : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Inquiry.
        /// </summary>
        public Inquiry? Inquiry { get; set; }

        /// <summary>
        /// Offer.
        /// </summary>
        public Offer? Offer { get; set; }
    }
}