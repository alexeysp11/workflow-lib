using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using VelocipedeUtils.Examples.Retail.Accounting.Models;

namespace VelocipedeUtils.Examples.Retail.Accounting.Services
{
    public class AccountingRepository : IAccountingRepository
    {
        #region ImportDoc
        public void InsertImportDoc(string docNum, string employeeName, 
            string supplierName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName);
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null);
                employeeId = EmployeeService.GetEmployeeId(employeeName);
            }

            int? supplierId = PartnerService.GetPartnerId(supplierName);
            if (supplierId == null)
            {
                PartnerService.InsertPartner(supplierName, string.Empty, string.Empty);
                supplierId = PartnerService.GetPartnerId(supplierName);
            }

            ImportService.InsertImportDoc(docNum, (int)employeeId, (int)supplierId, dateTime);
        }

        public IEnumerable<ImportDocInfo> GetImportDocs()
        {
            return ImportService.GetImportDocs();
        }

        public void UpdateImportDoc(int importDocId, string docNum, 
            string employeeName, string supplierName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName);
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null);
                employeeId = EmployeeService.GetEmployeeId(employeeName);
            }

            int? supplierId = PartnerService.GetPartnerId(supplierName);
            if (supplierId == null)
            {
                PartnerService.InsertPartner(supplierName, string.Empty, string.Empty);
                supplierId = PartnerService.GetPartnerId(supplierName);
            }

            ImportService.UpdateImportDoc( importDocId, docNum, (int)employeeId, 
                (int)supplierId, dateTime );
        }

        public void DeleteImportDoc(int importDocId)
        {
            ImportService.DeleteImportDoc(importDocId);
        }
        #endregion  // ImportDoc

        #region ImportItem
        public void InsertImportItem(string productTitle, float quantity, 
            float price, int importDocId)
        {
            ImportService.InsertImportItem(productTitle, quantity, price, 
                importDocId);
        }

        public IEnumerable<ImportItemInfo> GetImportItems(int importDocId)
        {
            return ImportService.GetImportItems(importDocId);
        }

        public void UpdateImportItem(int importItemId, string productTitle, 
            float quantity, float price)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle);
                var product = ProductService.GetProducts()
                    .Where(p => p.Title == productTitle)
                    .First();
                ImportService.UpdateImportItem(importItemId, product.ProductId, 
                    quantity, price);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void DeleteImportItem(int importItemId)
        {
            ImportService.DeleteImportItem(importItemId);
        }
        #endregion  // ImportItem

        #region ExportDoc
        public void InsertExportDoc(string docNum, string employeeName, 
            string purchaserName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName);
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null);
                employeeId = EmployeeService.GetEmployeeId(employeeName);
            }

            int? purchaserId = PartnerService.GetPartnerId(purchaserName);
            if (purchaserId == null)
            {
                PartnerService.InsertPartner(purchaserName, string.Empty, string.Empty);
                purchaserId = PartnerService.GetPartnerId(purchaserName);
            }

            ExportService.InsertExportDoc(docNum, (int)employeeId, (int)purchaserId, dateTime);
        }

        public IEnumerable<ExportDocInfo> GetExportDocs()
        {
            return ExportService.GetExportDocs();
        }

        public void UpdateExportDoc(int exportDocId, string docNum, 
            string employeeName, string purchaserName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName);
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null);
                employeeId = EmployeeService.GetEmployeeId(employeeName);
            }

            int? purchaserId = PartnerService.GetPartnerId(purchaserName);
            if (purchaserId == null)
            {
                PartnerService.InsertPartner(purchaserName, string.Empty, string.Empty);
                purchaserId = PartnerService.GetPartnerId(purchaserName);
            }

            ExportService.UpdateExportDoc( exportDocId, docNum, (int)employeeId, 
                (int)purchaserId, dateTime );
        }

        public void DeleteExportDoc(int exportDocId)
        {
            ExportService.DeleteExportDoc(exportDocId);
        }
        #endregion  // ExportDoc

        #region ExportItem
        public void InsertExportItem(string productTitle, float quantity, 
            float price, int exportDocId)
        {
            ExportService.InsertExportItem(productTitle, quantity, price, 
                exportDocId);
        }

        public IEnumerable<ExportItemInfo> GetExportItems(int exportDocId)
        {
            return ExportService.GetExportItems(exportDocId);
        }

        public void UpdateExportItem(int exportItemId, string productTitle, 
            float quantity, float price)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle);
                var product = ProductService.GetProducts()
                    .Where(p => p.Title == productTitle)
                    .First();
                ExportService.UpdateExportItem(exportItemId, product.ProductId, 
                    quantity, price);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void DeleteExportItem(int exportItemId)
        {
            ExportService.DeleteExportItem(exportItemId);
        }
        #endregion  // ExportItem

        #region Employees
        public void InsertEmployee(string employeeName, float salary, 
            string email, string phone, string managerName, 
            string departmentTitle)
        {
            int? managerId = EmployeeService.GetEmployeeId(managerName);
            if (managerId == null)
            {
                EmployeeService.InsertEmployee(managerName, 0, string.Empty, 
                    string.Empty, null, null);
                managerId = EmployeeService.GetEmployeeId(managerName);
            }

            DepartmentService.InsertDepartmentIfNotExists(departmentTitle);
            int? departmentId = DepartmentService.GetDepartmentId(departmentTitle);

            EmployeeService.InsertEmployee(employeeName, salary, email, phone, 
                managerId, departmentId);
        }

        public IEnumerable<EmployeeInfo> GetEmployees()
        {
            return EmployeeService.GetEmployees();
        }

        public void UpdateEmployee(int employeeId, string employeeName, 
            float salary, string email, string phone, string managerName, 
            string departmentTitle)
        {
            int? managerId = EmployeeService.GetEmployeeId(managerName);
            if (managerId == null)
            {
                EmployeeService.InsertEmployee(managerName, 0, string.Empty, 
                    string.Empty, null, null);
                managerId = EmployeeService.GetEmployeeId(managerName);
            }

            DepartmentService.InsertDepartmentIfNotExists(departmentTitle);
            int? departmentId = DepartmentService.GetDepartmentId(departmentTitle);

            EmployeeService.UpdateEmployee(employeeId, employeeName, salary, 
                email, phone, managerId, departmentId);
        }

        public void DeleteEmployee(int employeeId)
        {
            EmployeeService.DeleteEmployee(employeeId);
        }
        #endregion  // Employees

        #region Partners
        public void InsertPartner(string partnerName, string email, string phone)
        {
            PartnerService.InsertPartner(partnerName, email, phone);
        }

        public List<Partner> GetPartners()
        {
            return PartnerService.GetPartners();
        }

        public void UpdatePartner(int partnerId, string partnerName, 
            string email, string phone)
        {
            PartnerService.UpdatePartner(partnerId, partnerName, email, phone);
        }

        public void DeletePartner(int partnerId)
        {
            PartnerService.DeletePartner(partnerId);
        }
        #endregion  // Partners

        #region MainCompany
        public MainCompany GetMainCompany()
        {
            string path = "C:\\Users\\User\\Desktop\\projects\\Retail-Accounting-WebApp\\DB\\MainCompany.xml";
            MainCompany mainCompany = MainCompanyService.FromXmlFile<MainCompany>(path);
            return mainCompany;
        }
        
        public void SetMainCompany(string companyName, string owner, 
            string country, string city)
        {
            string path = "C:\\Users\\User\\Desktop\\projects\\Retail-Accounting-WebApp\\DB\\MainCompany.xml";
            XElement xmlTree1 = new XElement("MainCompany",  
                new XElement("CompanyName", companyName),  
                new XElement("Owner", owner),  
                new XElement("Country", country),  
                new XElement("City", city) 
            );
            xmlTree1.Save(path);
        }
        #endregion  // MainCompany

        #region Reports 
        public IEnumerable<ProductRevenueInfo> GetProductRevenueInfo()
        {
            return ReportService.GetProductRevenueInfo();
        }

        public IEnumerable<PersonalRevenueInfo> GetPersonalRevenue()
        {
            return ReportService.GetPersonalRevenue();
        }

        public IEnumerable<ProductRemainsInfo> GetProductRemainsReport()
        {
            return ReportService.GetProductRemainsReport();
        }
        #endregion  // Reports 
    }
}