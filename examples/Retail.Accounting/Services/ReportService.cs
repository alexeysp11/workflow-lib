using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.Retail.Accounting.Models; 

namespace WorkflowLib.Examples.Retail.Accounting.Services
{
    public static class ReportService
    {
        public static IEnumerable<ProductRevenueInfo> GetProductRevenueInfo()
        {
            IEnumerable<ProductRevenueInfo> products; 
            using (var db = new AccountingContext())
            {
                products = (from import in db.Set<ImportItem>()
                    from export in db.Set<ExportItem>()
                        .Where(export => import.ProductId == export.ProductId)
                    from product in db.Set<Product>()
                        .Where(product => import.ProductId == product.ProductId)
                    select new 
                    {
                        ProductId = import.ProductId, 
                        ProductTitle = product.Title, 
                        TotalRevenue = export.Price - import.Price, 
                        WeightedRevenue = (export.Price - import.Price) / export.Quantity, 
                        ExportQuantity = export.Quantity 
                    })
                    .ToList()
                    .GroupBy (s => new { s.ProductId, s.ProductTitle } )
                    .Select (g => 
                        new ProductRevenueInfo
                        {
                            ProductId = g.Key.ProductId,
                            ProductTitle = g.Key.ProductTitle,
                            TotalRevenue = (float)Math.Round( g.Sum(x => x.TotalRevenue), 3 ),
                            WeightedRevenue = (float)Math.Round( g.Sum(x => x.WeightedRevenue), 3 ),
                            ExportQuantity = (float)Math.Round( g.Sum(x => x.ExportQuantity), 3)
                        }
                    );
            }
            return products; 
        }

        public static IEnumerable<PersonalRevenueInfo> GetPersonalRevenue()
        {
            IEnumerable<PersonalRevenueInfo> employeeStats; 
            using (var db = new AccountingContext())
            {
                employeeStats = (from ed in db.Set<ExportDoc>()
                    from ei in db.Set<ExportItem>()
                        .Where(ei => ed.ExportDocId == ei.ExportDocId)
                    from e in db.Set<Employee>()
                        .Where(e => ed.EmployeeId == e.EmployeeId)
                    select new 
                    {
                        EmployeeId = ed.EmployeeId, 
                        EmployeeName = e.EmployeeName, 
                        TotalRevenue = ei.Price, 
                        WeightedRevenue = ei.Price / ei.Quantity
                    })
                    .ToList()
                    .GroupBy (s => new { s.EmployeeId, s.EmployeeName } )
                    .Select (g => 
                        new PersonalRevenueInfo
                        {
                            EmployeeId = g.Key.EmployeeId,
                            EmployeeName = g.Key.EmployeeName,
                            TotalRevenue = (float)Math.Round( g.Sum(x => x.TotalRevenue), 3 ),
                            WeightedRevenue = (float)Math.Round( g.Sum(x => x.WeightedRevenue), 3 )
                        }
                    );
            }
            return employeeStats; 
        }

        public static IEnumerable<ProductRemainsInfo> GetProductRemainsReport()
        {
            IEnumerable<ProductRemainsInfo> products; 
            using (var db = new AccountingContext())
            {
                products = (from p in db.Set<Product>()
                    from ei in db.Set<ExportItem>()
                        .Where(ei => p.ProductId == ei.ProductId)
                    from ii in db.Set<ImportItem>()
                        .Where(ii => p.ProductId == ii.ProductId)
                    select new 
                    {
                        ProductId = p.ProductId, 
                        ProductTitle = p.Title, 
                        QuantityLeft = ii.Quantity - ei.Quantity, 
                        PriceImport = ii.Price
                    })
                    .ToList()
                    .GroupBy (s => new { s.ProductId, s.ProductTitle } )
                    .Select (g => 
                        new ProductRemainsInfo
                        {
                            ProductId = g.Key.ProductId,
                            ProductTitle = g.Key.ProductTitle,
                            QuantityLeft = (float)Math.Round( g.Sum(x => x.QuantityLeft), 3 ),
                            AvgPriceImport = (float)Math.Round( g.Average(x => x.PriceImport), 3 )
                        }
                    );
            }
            return products; 
        }
    }
}