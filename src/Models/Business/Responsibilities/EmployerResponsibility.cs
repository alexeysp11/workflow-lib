namespace Cims.WorkflowLib.Models.Business.Responsibilities
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployerResponsibility
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
        public EmployerResponsibilityType ResponsibilityType { get; set; }
    }
}