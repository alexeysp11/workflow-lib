namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Period
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime From { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime To { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.TimeSpan TimeDifference { get { return To - From; } }
    }
}