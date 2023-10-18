using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Warehouse item.
    /// </summary>
    public class WarehouseItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public Warehouse Warehouse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WarehouseItemStatus WarehouseItemStatus { get; set; }
    }
}