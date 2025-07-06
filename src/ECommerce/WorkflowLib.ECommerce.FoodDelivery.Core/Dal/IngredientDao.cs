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
        /// <param name="context"></param>
        /// <param name="productId"></param>
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
    }
}
