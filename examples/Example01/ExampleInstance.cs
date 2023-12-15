using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Example01.Contexts;
using Cims.WorkflowLib.Example01.Data;
using Cims.WorkflowLib.Example01.FlowchartSteps;
using Cims.WorkflowLib.Example01.Interfaces;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01
{
    /// <summary>
    /// 
    /// </summary>
    public class ExampleInstance : IExampleInstance
    {
        private DbContextOptions<DeliveringContext> _contextOptions { get; set; }

        private MakeOrderStep _step01 { get; set; }
        private MakePaymentStep _step02 { get; set; }
        private FinishWh2KitchenStep _step03 { get; set; }
        private RequestStore2WhStep _step04 { get; set; }
        private FinishStore2WhStep _step05 { get; set; }
        private ConfirmStore2WhStep _step06 { get; set; }
        private PrepareMealStep _step07 { get; set; }
        private Kitchen2WhStep _step08 { get; set; }
        private ScanQrOnOrderStep _step09 { get; set; }
        private ScanBackpackStep _step10 { get; set; }
        private DeliverOrderStep _step11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExampleInstance(
            DbContextOptions<DeliveringContext> contextOptions,
            MakeOrderStep step01, 
            MakePaymentStep step02, 
            FinishWh2KitchenStep step03, 
            RequestStore2WhStep step04, 
            FinishStore2WhStep step05, 
            ConfirmStore2WhStep step06, 
            PrepareMealStep step07, 
            Kitchen2WhStep step08, 
            ScanQrOnOrderStep step09, 
            ScanBackpackStep step10,
            DeliverOrderStep step11)
        {
            _contextOptions = contextOptions;
            _step01 = step01;
            _step02 = step02;
            _step03 = step03;
            _step04 = step04;
            _step05 = step05;
            _step06 = step06;
            _step07 = step07;
            _step08 = step08;
            _step09 = step09;
            _step10 = step10;
            _step11 = step11;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            // Provide configurations for DbContext.
            ConfigureDbContext();

            // Step 01: make order.
            System.Console.WriteLine("\nStep 01: make order.");
            _step01.Start();

            // Step 02: make payment.
            System.Console.WriteLine("\nStep 02: make payment.");
            _step02.Start();

            // // Step 03: finish delivering from warehouse to kitchen.
            // System.Console.WriteLine("\nStep 03: finish delivering from warehouse to kitchen.");
            // _step03.Start();

            // Step 04: request for delivering from store to warehouse.
            // System.Console.WriteLine("\nStep 04: request for delivering from store to warehouse.");
            // _step04.Start();

            // // Step 05: deliver from store to warehouse.
            // System.Console.WriteLine("\nStep 05: deliver from store to warehouse.");
            // _step05.Start();

            // // Step 06: confirm delivering from store to warehouse.
            // System.Console.WriteLine("\nStep 06: confirm delivering from store to warehouse.");
            // _step06.Start();

            // // Step 07: prepare meal.
            // System.Console.WriteLine("\nStep 07: prepare meal.");
            // _step07.Start();

            // // Step 08: deliver from kitchen to warehouse.
            // System.Console.WriteLine("\nStep 08: deliver from kitchen to warehouse.");
            // _step08.Start();

            // // Step 09: scan QR code on the delivery order.
            // System.Console.WriteLine("\nStep 09: scan QR code on the delivery order.");
            // _step09.Start();

            // // Step 10: scan backpack.
            // System.Console.WriteLine("\nStep 10: scan backpack.");
            // _step10.Start();

            // // Step 11: deliver order.
            // System.Console.WriteLine("\nStep 11: deliver order.");
            // _step11.Start();
        }

        private void ConfigureDbContext()
        {
            ClearTables();
            AddUserAccounts();
            AddCustomers();
            AddCompanies();
            AddEmployees();
            AddContacts();
            AddWHProduct();
            AddIngredients();
            AddRecipes();
        }

        private void ClearTables()
        {
            using var context = new DeliveringContext(_contextOptions);
            
            context.UserAccounts.RemoveRange(context.UserAccounts.ToList());
            context.UserGroups.RemoveRange(context.UserGroups.ToList());

            context.InitialOrders.RemoveRange(context.InitialOrders.ToList());
            context.InitialOrderProducts.RemoveRange(context.InitialOrderProducts.ToList());
            context.DeliveryOrders.RemoveRange(context.DeliveryOrders.ToList());
            context.DeliveryOrderProducts.RemoveRange(context.DeliveryOrderProducts.ToList());
            context.Payments.RemoveRange(context.Payments.ToList());

            context.ProductCategories.RemoveRange(context.ProductCategories.ToList());
            context.Products.RemoveRange(context.Products.ToList());
            context.WHProducts.RemoveRange(context.WHProducts.ToList());
            context.Ingredients.RemoveRange(context.Ingredients.ToList());
            context.Recipes.RemoveRange(context.Recipes.ToList());

            context.Notifications.RemoveRange(context.Notifications.ToList());
            context.DeliveryOperations.RemoveRange(context.DeliveryOperations.ToList());

            context.SaveChanges();
        }

        private void AddUserAccounts()
        {
            using var context = new DeliveringContext(_contextOptions);
            for (int i = 1; i <= 10; i++)
            {
                context.UserAccounts.Add(new UserAccount
                {
                    Id = i,
                    Uid = System.Guid.NewGuid().ToString(),
                    Login = "login" + i,
                    Email = "user" + i + "@example.com",
                    PhoneNumber = "PhoneNumber" + i,
                    Password = "pswd" + i
                });
            }
            var admin = context.UserAccounts.FirstOrDefault(x => x.Id == 1);
            var dtnow = System.DateTime.Now;
            for (int i = 1; i <= 5; i++)
            {
                var users = context.UserAccounts.Where(x => x.Id % 5 == i - 1).ToList();
                context.UserGroups.Add(new UserGroup
                {
                    Id = i,
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = "usergroup" + i,
                    Users = users,
                    CreationAuthor = admin,
                    CreationDate = dtnow,
                    ChangeAuthor = admin,
                    ChangeDate = dtnow
                });
            }
            context.SaveChanges();
        }

        private void AddCustomers()
        {
            // потребители, 
        }

        private void AddCompanies()
        {
            // компании, 
            // организации, 
            // элементы организации, 
        }

        private void AddEmployees()
        {
            // сотрудники, 
        }

        private void AddContacts()
        {
            // контакты, 
            // адреса
        }

        private void AddWHProduct()
        {
            using var context = new DeliveringContext(_contextOptions);
            var rand = new System.Random();

            var pcid = context.ProductCategories.Count() + 1;
            var productCategory = new ProductCategory
            {
                Id = pcid,
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Product category " + pcid
            };
            context.ProductCategories.Add(productCategory);
            for (int i = 0; i < 3; i++)
                AddSingleWHProduct(context, rand, productCategory);
            context.SaveChanges();
        }

        private void AddSingleWHProduct(
            DeliveringContext context, 
            System.Random rand, 
            ProductCategory productCategory)
        {
            var pid = context.Products.Count() + 1;
            var whpid = context.WHProducts.Count() + 1;
            var product = new Product
            {
                Id = pid,
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Product " + pid,
                Price = rand.Next(12, 31),
                Quantity = 0,
                ProductCategory = productCategory
            };
            var whproduct = new WHProduct
            {
                Id = whpid,
                Uid = System.Guid.NewGuid().ToString(),
                Name = "WHProduct " + whpid,
                Product = product,
                Quantity = rand.Next(2, 7),
                MinQuantity = rand.Next(3, 5),
                MaxQuantity = rand.Next(20, 46)
            };
            context.Products.Add(product);
            context.WHProducts.Add(whproduct);
            context.SaveChanges();
        }

        private void AddIngredients()
        {
            using var context = new DeliveringContext(_contextOptions);
            var rand = new System.Random();

            var pcid = context.ProductCategories.Count() + 1;
            var productCategory = new ProductCategory
            {
                Id = pcid,
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Product category " + pcid,
                Description = "Ingredients"
            };
            context.ProductCategories.Add(productCategory);
            var finalProduct1 = context.Products.FirstOrDefault(x => x.Id == 1);
            var finalProduct2 = context.Products.FirstOrDefault(x => x.Id == 2);
            var finalProduct3 = context.Products.FirstOrDefault(x => x.Id == 3);
            AddSingleIngredient(context, rand, productCategory, finalProduct1);
            AddSingleIngredient(context, rand, productCategory, finalProduct1);
            AddSingleIngredient(context, rand, productCategory, finalProduct2);
            AddSingleIngredient(context, rand, productCategory, finalProduct2);
            AddSingleIngredient(context, rand, productCategory, finalProduct2);
            AddSingleIngredient(context, rand, productCategory, finalProduct3);
            context.SaveChanges();
        }

        private void AddSingleIngredient(
            DeliveringContext context, 
            System.Random rand, 
            ProductCategory productCategory, 
            Product finalProduct)
        {
            var pid = context.Products.Count() + 1;
            var whpid = context.WHProducts.Count() + 1;
            var product = new Product
            {
                Id = pid,
                Uid = System.Guid.NewGuid().ToString(),
                Name = "Product " + pid,
                Price = rand.Next(2, 7),
                Quantity = 0,
                ProductCategory = productCategory
            };
            var ingredient = new Ingredient
            {
                Id = context.Ingredients.Count() + 1,
                Uid = System.Guid.NewGuid().ToString(),
                Name = product.Name,
                FinalProduct = finalProduct,
                IngredientProduct = product
            };
            var whproduct = new WHProduct
            {
                Id = whpid,
                Uid = System.Guid.NewGuid().ToString(),
                Name = "WHProduct " + whpid,
                Product = product,
                Quantity = rand.Next(1, 16),
                MinQuantity = rand.Next(3, 5),
                MaxQuantity = rand.Next(20, 46)
            };
            context.Ingredients.Add(ingredient);
            context.WHProducts.Add(whproduct);
            context.SaveChanges();
        }

        private void AddRecipes()
        {
            using var context = new DeliveringContext(_contextOptions);

            int recipeId = 1;
            var sbRecipeName = new StringBuilder();
            var sbInstruction = new StringBuilder();
            var ingredientIds = (from ingredient in context.Ingredients select ingredient.IngredientProduct.Id).ToList(); 
            foreach (var p in context.Products.Where(x => !ingredientIds.Any(i => i == x.Id)))
            {
                sbInstruction.Append("Instruction #").Append(recipeId.ToString());
                sbRecipeName.Append("Recipe of the product #").Append(p.Id.ToString()).Append(" ").Append(p.Name);
                var recipe = new Recipe
                {
                    Id = recipeId,
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = sbRecipeName.ToString(),
                    Product = p,
                    Ingredients = context.Ingredients.Where(x => x.FinalProduct != null && x.FinalProduct.Uid == p.Uid).ToList(),
                    Instruction = sbInstruction.ToString()
                };
                context.Recipes.Add(recipe);
                sbInstruction.Clear();
                sbRecipeName.Clear();
                recipeId += 1;
            }
            context.SaveChanges();
        }
    }
}