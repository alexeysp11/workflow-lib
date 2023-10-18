namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Address : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public string AdditionalInfo { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string RoomNumber { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int Floor { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string StreetNumber { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string StreetName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string CountryProvince { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Country { get; set; }
    }
}