using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Monetary;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// 
    /// </summary>
    public class DeliveryOrder
    {
        public string OrderUid { get; set; }
        public string Number { get; set; }
        public System.DateTime OpenOrderDt { get; set; }
        public System.DateTime CloseOrderDt { get; set; }
        public string UserUid { get; set; }
        public string CompanyUid { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<BusinessOperation> PreparingOperations { get; set; }
        public BusinessOperation DeliveryOperation { get; set; }
        public List<Product> Products { get; set; }
        public float ProductsPrice { get; set; }
        public float AdditonalPrice { get; set; }
        public float DeliveryPrice { get; set; }
        public float TaxPrice { get; set; }
        public float TotalPrice { get; set; }
        public Address Origin { get; set; }
        public Address Destination { get; set; }
        public List<Payment> Payments { get; set; }
        public string Status { get; set; }
    }
}