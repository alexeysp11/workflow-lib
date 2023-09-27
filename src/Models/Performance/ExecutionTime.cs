namespace Cims.WorkflowLib.Models.Performance
{
    /// <summary>
    /// 
    /// </summary>
    public class ExecutionTime
    {
        public System.DateTime DateTimeBegin { get; set; }
        public System.DateTime DateTimeEnd { get; set; }
        public System.TimeSpan TimeDifference { get { return DateTimeEnd - DateTimeBegin; } }
    }
}