using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Business process diagram element.
    /// </summary>
    public class BusinessDiagramElement : BusinessEntityWF, IBusinessEntityWF
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