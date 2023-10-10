namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Replacement
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
        public int PreReplace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool DuplicateMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserAccount SourceUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserAccount TargetUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReplacementStatus Status { get; set; }
    }
}