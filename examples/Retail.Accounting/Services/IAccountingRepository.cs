using System; 
using System.Collections.Generic;
using WorkflowLib.Examples.Retail.Accounting.Models; 

namespace WorkflowLib.Examples.Retail.Accounting.Services
{
    public interface IAccountingRepository
    {
        void InsertImportDoc(string docNum, string employeeName, 
            string supplierName, DateTime dateTime); 
        IEnumerable<ImportDocInfo> GetImportDocs(); 
        void UpdateImportDoc(int importDocId, string docNum, 
            string employeeName, string supplierName, DateTime dateTime); 
        void DeleteImportDoc(int importDocId); 

        void InsertExportDoc(string docNum, string employeeName, 
            string purchaserName, DateTime dateTime); 
        IEnumerable<ExportDocInfo> GetExportDocs(); 
        void UpdateExportDoc(int exportDocId, string docNum, 
            string employeeName, string purchaserName, DateTime dateTime); 
        void DeleteExportDoc(int exportDocId); 

        void InsertEmployee(string employeeName, float salary, 
            string email, string phone, string managerName, 
            string departmentTitle); 
        IEnumerable<EmployeeInfo> GetEmployees(); 
        void UpdateEmployee(int employeeId, string employeeName, 
            float salary, string email, string phone, string managerName, 
            string departmentTitle); 
        void DeleteEmployee(int employeeId); 

        void InsertPartner(string partnerName, string email, string phone); 
        List<Partner> GetPartners(); 
        void UpdatePartner(int partnerId, string partnerName, string email, 
            string phone); 
        void DeletePartner(int PartnerId); 

        void InsertImportItem(string productTitle, float quantity, 
            float price, int importDocId); 
        IEnumerable<ImportItemInfo> GetImportItems(int importDocId); 
        void UpdateImportItem(int importItemId, string productTitle, 
            float quantity, float price); 
        void DeleteImportItem(int importItemId); 
        
        void InsertExportItem(string productTitle, float quantity, 
            float price, int exportDocId); 
        IEnumerable<ExportItemInfo> GetExportItems(int exportDocId);
        void UpdateExportItem(int exportItemId, string productTitle, 
            float quantity, float price); 
        void DeleteExportItem(int exportItemId); 

        MainCompany GetMainCompany(); 
        void SetMainCompany(string companyName, string owner, 
            string country, string city); 
        
        IEnumerable<ProductRevenueInfo> GetProductRevenueInfo(); 
        IEnumerable<PersonalRevenueInfo> GetPersonalRevenue(); 
        IEnumerable<ProductRemainsInfo> GetProductRemainsReport(); 
    }
}