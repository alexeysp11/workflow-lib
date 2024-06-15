using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Processes
{
    /// <summary>
    /// General description of the business process (for example, candidate selection).
    /// </summary>
    public class BusinessProcess : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// The diagram associated with the business process.
        /// </summary>
        public BusinessDiagram? Diagram { get; set; }

        /// <summary>
        /// Parent instance of the business process.
        /// </summary>
        public BusinessProcess? Parent { get; set; }

        /// <summary>
        /// Collection of the sub-processes.
        /// </summary>
        public ICollection<BusinessProcess> SubProcesses { get; set; }

        /// <summary>
        /// Version number of the business process.
        /// </summary>
        public string? VersionNumber { get; set; }
    }
}