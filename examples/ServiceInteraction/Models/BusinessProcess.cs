using System.Collections.Generic;
namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Represents a business process entity with workflow functionality.
    /// </summary>
    public class BusinessProcess : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Gets or sets the parent business process.
        /// </summary>
        public BusinessProcess? Parent { get; set; }

        /// <summary>
        /// Gets or sets the collection of sub processes related to this business process.
        /// </summary>
        public ICollection<BusinessProcess> SubProcesses { get; set; }

        /// <summary>
        /// Gets or sets the version number of the business process.
        /// </summary>
        public string? VersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the date when the business process was created.
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}