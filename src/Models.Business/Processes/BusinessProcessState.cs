namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Represents a state of a business process with workflow functionality.
    /// </summary>
    public class BusinessProcessState : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Gets or sets the associated business process.
        /// </summary>
        public BusinessProcess? BusinessProcess { get; set; }
        
        /// <summary>
        /// Gets or sets the date when the business process state was created.
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}