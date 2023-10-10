namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// 
    /// </summary>
    public class Company
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
        public string RegistrationNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string VatNumber { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficeEmail { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfficePhone { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShippingAddress { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HasVatRegistration { get; private set; }

        //public ICollection<Employee> Employees { get; private set; }

        //public ICollection<Project> Projects { get; private set; }
    }
}