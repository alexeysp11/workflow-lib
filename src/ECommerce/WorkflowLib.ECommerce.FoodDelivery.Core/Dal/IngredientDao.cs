using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.Cooking;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    public static class IngredientDao
    {
        /// <summary>
        /// Get ingredient list by final product ID.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="productId">Final product ID</param>
        /// <returns></returns>
        public static List<Ingredient> GetIngredientsByFinalProductId(
            FoodDeliveryDbContext context,
            long productId)
        {
            return context.Ingredients
                .Include(x => x.IngredientProduct)
                .Where(x => x.FinalProduct.Id == productId)
                .ToList();
        }

        /// <summary>
        /// Get ingredients by multiple final product IDs.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="productIds">Final product IDs</param>
        /// <returns></returns>
        internal static List<Ingredient> GetIngredientsByMulipleFinalProductIds(
            FoodDeliveryDbContext context,
            List<long> productIds)
        {
            return context.Ingredients
                .Include(x => x.IngredientProduct)
                .Include(x => x.FinalProduct)
                .Where(x => productIds.Any(pid => pid == x.FinalProduct.Id))
                .ToList();
        }
    }
}
