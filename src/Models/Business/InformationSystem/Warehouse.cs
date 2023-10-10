namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Warehouse
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
        public OrganizationItem OrganizationItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StorehouseItem> StorehouseItems { get; set; }
    }
}