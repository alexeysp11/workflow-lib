using System;
using System.Collections.Generic;
using System.Linq;
using VelocipedeUtils.Examples.Retail.Accounting.Models;

namespace VelocipedeUtils.Examples.Retail.Accounting.Services
{
    public static class ImportService
    {
        public static void InsertImportDoc(string docNum, int employeeId, 
            int supplierId, DateTime dateTime)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new ImportDoc 
                { 
                    DocNum = docNum, 
                    EmployeeId = employeeId, 
                    SupplierId = supplierId, 
                    DateTime = dateTime 
                });
                db.SaveChanges();
            }
        }

        public static void InsertImportItem(string productTitle, float quantity, 
            float price, int importDocId)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle);
                using (var db = new AccountingContext())
                {
                    var product = db.Product.Where(p => p.Title == productTitle).ToList();
                    db.Add(new ImportItem 
                    { 
                        Quantity = quantity, 
                        Price = price, 
                        ProductId = product[0].ProductId, 
                        ImportDocId = importDocId 
                    });
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<ImportDocInfo> GetImportDocs()
        {
            IEnumerable<ImportDocInfo> importDocs;
            using (var db = new AccountingContext())
            {
                importDocs = (from id in db.Set<ImportDoc>()
                    from c in db.Set<Partner>().Where(c => id.SupplierId == c.PartnerId) 
                    from e in db.Set<Employee>().Where(e => id.EmployeeId == e.EmployeeId) 
                    select new ImportDocInfo
                    {
                        ImportDocId = id.ImportDocId, 
                        DocNum = id.DocNum, 
                        EmployeeName = e.EmployeeName,
                        SupplierName = c.PartnerName, 
                        DateTime = id.DateTime
                    }).ToList();
            }
            return importDocs;
        }

        public static IEnumerable<ImportItemInfo> GetImportItems(int importDocId)
        {
            IEnumerable<ImportItemInfo> importItems;
            using (var db = new AccountingContext())
            {
                importItems = (from ii in db.Set<ImportItem>()
                    from p in db.Set<Product>().Where(p => ii.ProductId == p.ProductId)
                    where ii.ImportDocId == importDocId
                    select new ImportItemInfo 
                    { 
                        ImportItemId = ii.ImportItemId, 
                        ProductName = p.Title, 
                        Quantity = ii.Quantity,
                        Price = ii.Price, 
                        TotalPrice = ii.Quantity * ii.Price
                    }).ToList();
            }
            return importItems;
        }

        public static void UpdateImportDoc(int importDocId, string docNum, 
            int employeeId, int supplierId, DateTime dateTime)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var importDoc = db.ImportDocs
                        .Where(id => id.ImportDocId == importDocId)
                        .ToList()
                        .First();
                    importDoc.DocNum = docNum;
                    importDoc.EmployeeId = employeeId;
                    importDoc.SupplierId = supplierId;
                    importDoc.DateTime = dateTime;
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void UpdateImportItem(int importItemId, int productId, 
            float quantity, float price)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var importItem = db.ImportItems
                        .Where(ii => ii.ImportItemId == importItemId)
                        .ToList()
                        .First();
                    importItem.ProductId = productId;
                    importItem.Quantity = quantity;
                    importItem.Price = price;
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void DeleteImportDoc(int importDocId)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var importDoc = db.ImportDocs
                        .Where(ii => ii.ImportDocId == importDocId)
                        .ToList()
                        .First();
                    db.Remove(importDoc);
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void DeleteImportItem(int importItemId)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var importItem = db.ImportItems
                        .Where(ii => ii.ImportItemId == importItemId)
                        .ToList()
                        .First();
                    db.Remove(importItem);
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}