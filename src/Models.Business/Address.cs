namespace WorkflowLib.Models.Business
{
    /// <summary>
    /// Address.
    /// </summary>
    public class Address : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Additional info.
        /// </summary>
        public string AdditionalInfo { get; set; }
        
        /// <summary>
        /// Room number.
        /// </summary>
        public string RoomNumber { get; set; }
        
        /// <summary>
        /// Floor.
        /// </summary>
        public int Floor { get; private set; }
        
        /// <summary>
        /// Street number (number of a house).
        /// </summary>
        public string StreetNumber { get; set; }
        
        /// <summary>
        /// Street name.
        /// </summary>
        public string StreetName { get; set; }
        
        /// <summary>
        /// Postal code.
        /// </summary>
        public string PostalCode { get; set; }
        
        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Country province.
        /// </summary>
        public string CountryProvince { get; set; }
        
        /// <summary>
        /// Country.
        /// </summary>
        public string Country { get; set; }
    }
}