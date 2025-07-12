using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Offer.
    /// </summary>
    public class Offer : WfBusinessEntity, IWfBusinessEntity, ISendableBusinessEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string? HtmlContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ContractId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Revision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateLastRevised { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateApproved { get; set; }

        /// <summary>
        /// Date the business entity was sent.
        /// </summary>
        public DateTime? DateSent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? SentById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee? EmployeeSent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? CreatedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee? EmployeeCreated { get; set; }

        //public CompanyContract Contract { get; set; }
    }
}