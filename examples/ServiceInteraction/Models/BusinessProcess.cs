using System.Collections.Generic;
namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// General description of the business process (for example, candidate selection).
    /// </summary>
    public class BusinessProcess : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public BusinessProcess? Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<BusinessProcess> SubProcesses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? VersionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}