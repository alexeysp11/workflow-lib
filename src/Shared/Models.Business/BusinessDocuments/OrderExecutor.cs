using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Associate table between any executor and order.
    /// </summary>
    public class OrderExecutor : WfBusinessEntity, IWfBusinessEntity, ITemporalWfBusinessEntity
    {
        /// <summary>
        /// Executor UID of the order.
        /// </summary>
        public string? ExecutorUid { get; set; }

        /// <summary>
        /// Executor name of the order.
        /// </summary>
        public string? ExecutorName { get; set; }

        /// <summary>
        /// Type of the executor in the order.
        /// </summary>
        public OrderExecutorType? OrderExecutorType { get; set; }

        /// <summary>
        /// Importance of the executor in the order.
        /// </summary>
        public OrderExecutorImportance? OrderExecutorImportance { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public Order? Order { get; set; }
        
        /// <summary>
        /// Actual start date.
        /// </summary>
        public System.DateTime? DateStartActual { get; set; }
        
        /// <summary>
        /// Actual end date.
        /// </summary>
        public System.DateTime? DateEndActual { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? DateStartExpected { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? DateEndExpected { get; set; }
    }
}