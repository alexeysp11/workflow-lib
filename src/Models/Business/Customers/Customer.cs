using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// Customer.
    /// </summary>
    public class Customer : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// First name of the customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name of the customer.
        /// </summary>
        public string MiddleName { get; set; }
        
        /// <summary>
        /// Last name of the customer.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Full name of the customer.
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Contact of the customer.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// User account of the customer.
        /// </summary>
        public UserAccount UserAccount { get; set; }

        /// <summary>
        /// Company of the customer.
        /// </summary>
        public Company Company { get; set; }
    }
}
