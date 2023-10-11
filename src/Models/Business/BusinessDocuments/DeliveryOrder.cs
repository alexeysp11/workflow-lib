using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// 
    /// </summary>
    public class DeliveryOrder
    {
        /// <summary>
        /// 
        /// </summary>
        public string OrderUid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime OpenOrderDt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CloseOrderDt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string UserUid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string CompanyUid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DeliveryMethod DeliveryMethod { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public List<BusinessOperation> PreparingOperations { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public BusinessOperation DeliveryOperation { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Product> Products { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal ProductsPrice { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal AdditonalPrice { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal DeliveryPrice { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal TaxPrice { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPrice { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Address Origin { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Address Destination { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Payment> Payments { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}