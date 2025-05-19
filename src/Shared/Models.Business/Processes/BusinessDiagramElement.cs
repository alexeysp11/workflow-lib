using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Processes
{
    /// <summary>
    /// Business process diagram element.
    /// </summary>
    public class BusinessDiagramElement : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public ICollection<BDEConnector> InputConnectors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public ICollection<BDEConnector> OutputConnectors { get; set; }
    }
}