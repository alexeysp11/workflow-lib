using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowLib.Examples.Retail.Accounting.Models; 

namespace WorkflowLib.Examples.Retail.Accounting.Services
{
    public static class ProductService
    {
        public static void InsertProductIfNotExists(string productTitle)
        {
            using (var db = new AccountingContext())
            {
                var productList = db.Product
                    .Where(p => p.Title == productTitle)
                    .ToList(); 
                if (productList.Count == 0)
                {
                    db.Add(new Product { Title = productTitle });
                    db.SaveChanges();
                }
            }
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>(); 
            using (var db = new AccountingContext())
            {
                products = db.Product.OrderBy(id => id.ProductId).ToList(); 
            }
            return products; 
        }
    }
}