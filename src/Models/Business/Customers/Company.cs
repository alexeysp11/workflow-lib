namespace Cims.WorkflowLib.Models.Business.Customers
{
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
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        public string RegistrationNumber { get; private set; }

        public string VatNumber { get; private set; }

        public string OfficeEmail { get; private set; }

        public string OfficePhone { get; private set; }

        public string Address { get; private set; }

        public string ShippingAddress { get; private set; }

        public bool HasVatRegistration { get; private set; }

        //public ICollection<Employee> Employees { get; private set; }

        //public ICollection<Project> Projects { get; private set; }
    }
}