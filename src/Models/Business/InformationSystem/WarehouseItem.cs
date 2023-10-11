using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

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