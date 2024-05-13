using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DAL;

/// <summary>
/// A class at the DAL level that performs operations related to business orders in the database.
/// </summary>
public class DeliveryOrderDAL
{
    private object m_object = new object();
    private DbContextOptions<ServiceInteractionDbContext> m_contextOptions;

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public DeliveryOrderDAL(
        DbContextOptions<ServiceInteractionDbContext> contextOptions) 
    {
        m_contextOptions = contextOptions;
    }

    /// <summary>
    /// Saves the specified initial order in the database.
    /// </summary>
    public void SaveInitialOrder(
        InitialOrder initialOrder)
    {
        using var context = new ServiceInteractionDbContext(m_contextOptions);

        decimal paymentAmount = 0.0m;
        var initialOrderProducts = new List<InitialOrderProduct>();
        var initialOrderIngredients = new List<InitialOrderIngredient>();
        foreach (var pid in initialOrder.ProductIds)
        {
            if (initialOrderProducts.Any(x => x.Product.Id == pid))
                continue;
            
            int productQty = initialOrder.ProductIds.Where(x => x == pid).Count();
            var product = context.Products.Where(x => x.Id == pid).FirstOrDefault();
            if (product == null)
                throw new System.Exception($"The product with the specified ID does not exist in the database: {pid}");
            paymentAmount += productQty * product.Price;
            var initialOrderProduct = new InitialOrderProduct
            {
                Uid = System.Guid.NewGuid().ToString(),
                Name = product.Name,
                Product = product,
                InitialOrder = initialOrder,
                Quantity = productQty
            };
            initialOrderProducts.Add(initialOrderProduct);

            var ingredientsTmp = context.Ingredients
                .Include(x => x.IngredientProduct)
                .Where(x => x.FinalProduct.Id == product.Id);
            foreach (var ingredient in ingredientsTmp)
            {
                initialOrderIngredients.Add(new InitialOrderIngredient
                {
                    Uid = System.Guid.NewGuid().ToString(),
                    Name = ingredient.Name,
                    Ingredient = ingredient,
                    InitialOrder = initialOrder,
                    InitialOrderProduct = initialOrderProduct,
                    Quantity = productQty * (int)ingredient.Quantity
                });
            }
        }

        if (Math.Abs(initialOrder.PaymentAmount - paymentAmount) >= 0.01m)
            throw new System.Exception($"Payment amount should be consistent (given: '{initialOrder.PaymentAmount}', re-calculated: '{paymentAmount}')");
        
        initialOrder.Uid = System.Guid.NewGuid().ToString();
        context.InitialOrderProducts.AddRange(initialOrderProducts);
        context.InitialOrderIngredients.AddRange(initialOrderIngredients);
        context.InitialOrders.Add(initialOrder);
        context.SaveChanges();
    }
}