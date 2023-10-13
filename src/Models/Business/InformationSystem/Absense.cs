namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Absense
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
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserAccount User { get; set; }
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
        public AbsenseReason Reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AbsenseStatus Status { get; set; }
    }
}