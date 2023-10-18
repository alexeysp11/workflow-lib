using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Warehouse : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public OrganizationItem OrganizationItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}