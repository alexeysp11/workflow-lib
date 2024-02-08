namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Business entity in the workflow-lib.
    /// </summary>
    public abstract class BusinessEntityWF : IBusinessEntityWF
    {
        /// <summary>
        /// ID of the business entity.
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// UID of the business entity.
        /// </summary>
        public string Uid { get; set; }
        
        /// <summary>
        /// Name of the business entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the business entity.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Business entity status.
        /// </summary>
        public BusinessEntityStatus BusinessEntityStatus { get; set; }
    }
}