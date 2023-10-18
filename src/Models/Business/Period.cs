namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// Period.
    /// </summary>
    public class Period
    {
        /// <summary>
        /// From.
        /// </summary>
        public System.DateTime From { get; private set; }

        /// <summary>
        /// To.
        /// </summary>
        public System.DateTime To { get; private set; }

        /// <summary>
        /// Time difference.
        /// </summary>
        public System.TimeSpan TimeDifference { get { return To - From; } }
    }
}