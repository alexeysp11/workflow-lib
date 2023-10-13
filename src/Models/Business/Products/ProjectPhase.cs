namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class ProjectPhase
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

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
        public Project Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectPlanItem ProjectPlanItem { get; set; }
    }
}