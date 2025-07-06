using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Cooking;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    public static class InitialOrderDao
    {
        /// <summary>
        /// Create initial order in the database.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="initialOrder">Initial order to create</param>
        public static void CreateInitialOrder(FoodDeliveryDbContext context, InitialOrder initialOrder)
        {
            List<InitialOrderProduct> initialOrderProducts = new List<InitialOrderProduct>();
            List<InitialOrderIngredient> initialOrderIngredients = new List<InitialOrderIngredient>();
            foreach (var pid in initialOrder.ProductIds)
            {
                if (initialOrderProducts.Any(x => x.Product.Id == pid))
                    continue;

                int productQty = initialOrder.ProductIds.Where(x => x == pid).Count();
                var product = context.Products.Where(x => x.Id == pid).FirstOrDefault();
                var initialOrderProduct = new InitialOrderProduct
                {
                    Uid = Guid.NewGuid().ToString(),
                    Name = product.Name,
                    Product = product,
                    InitialOrder = initialOrder,
                    Quantity = productQty
                };
                initialOrderProducts.Add(initialOrderProduct);

                List<Ingredient> ingredientsTmp = IngredientDao.GetIngredientsByFinalProductId(context, product.Id);
                foreach (var ingredient in ingredientsTmp)
                {
                    initialOrderIngredients.Add(new InitialOrderIngredient
                    {
                        Uid = Guid.NewGuid().ToString(),
                        Name = ingredient.Name,
                        Ingredient = ingredient,
                        InitialOrder = initialOrder,
                        InitialOrderProduct = initialOrderProduct,
                        Quantity = productQty * (int)ingredient.Quantity
                    });
                }

                initialOrder.PaymentAmount += productQty * product.Price;
            }
            initialOrder.Uid = Guid.NewGuid().ToString();
            context.InitialOrderProducts.AddRange(initialOrderProducts);
            context.InitialOrderIngredients.AddRange(initialOrderIngredients);
            context.InitialOrders.Add(initialOrder);
            context.SaveChanges();
        }

        /// <summary>
        /// Get initial order by ID.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="initialOrderId">Specified initial order ID</param>
        /// <returns></returns>
        public static InitialOrder? GetInitialOrderById(FoodDeliveryDbContext context, long initialOrderId)
        {
            return context.InitialOrders.FirstOrDefault(x => x.Id == initialOrderId);
        }
    }
}
