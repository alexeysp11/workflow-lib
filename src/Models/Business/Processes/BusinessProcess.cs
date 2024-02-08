using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// General description of the business process (for example, candidate selection).
    /// </summary>
    public class BusinessProcess : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public BusinessDiagram Diagram { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessProcess Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<BusinessProcess> SubProcesses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VersionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime DateCreated { get; set; }
    }
}