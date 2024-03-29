using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Warehouse.
    /// </summary>
    public class Warehouse : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Organization item related to the warehouse.
        /// </summary>
        public OrganizationItem OrganizationItem { get; set; }

        /// <summary>
        /// Warehouse items that are stored or related to the warehouse.
        /// </summary>
        public ICollection<WarehouseItem> WarehouseItems { get; set; }

        /// <summary>
        /// Location of the warehouse.
        /// </summary>
        public Address Location { get; set; }
    }
}