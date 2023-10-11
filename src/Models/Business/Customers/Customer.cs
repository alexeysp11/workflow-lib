using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// 
    /// </summary>
    public class Customer
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
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MiddleName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserAccount UserAccount { get; set; }
    }
}
