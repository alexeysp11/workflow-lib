using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.ECommerce.FoodDelivery.Core.Models;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Delivery;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    /// <summary>
    /// Food delivery DAO.
    /// </summary>
    public static class FoodDeliveryDao
    {
        /// <summary>
        /// Get delivery order by the specified order number.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="orderNumber">Specified order number</param>
        /// <returns></returns>
        public static DeliveryOrder? GetDeliveryOrderByNumber(
            FoodDeliveryDbContext context,
            string orderNumber)
        {
            // In the previous version, the following condition was used: ParentDeliveryOrder == null.

            return context.DeliveryOrders.FirstOrDefault(x => x.Number == orderNumber);
        }

        /// <summary>
        /// Get internal delivery order.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <returns></returns>
        public static DeliveryOrder? GetInternalDeliveryOrder(FoodDeliveryDbContext context)
        {
            // Check why the following condition is used: x.ParentDeliveryOrder != null.

            return context.DeliveryOrders.FirstOrDefault(x => x.ParentDeliveryOrder != null
                && x.OrderExecutorType == OrderExecutorType.Employee
                && x.OrderCustomerType == OrderCustomerType.Employee);
        }

        /// <summary>
        /// Get delivery operation.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOperationType">Delivery operation type</param>
        /// <returns></returns>
        public static DeliveryOperation? GetDeliveryOperation(
            FoodDeliveryDbContext context,
            string deliveryOperationType)
        {
            return context.DeliveryOperations
                .FirstOrDefault(x => x.DeliveryOperationType == deliveryOperationType);
        }

        /// <summary>
        /// Get delivery order total price.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrderId">Delivery order ID</param>
        /// <returns></returns>
        internal static float? GetDeliveryOrderTotalPrice(FoodDeliveryDbContext context, long deliveryOrderId)
        {
            return context.DeliveryOrderProducts
                .Where(x => x.DeliveryOrder.Id == deliveryOrderId)
                .Sum(x => (float?)x.Product.Price * x.Quantity);
        }

        /// <summary>
        /// Update delivery order total price.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrder">Delivery order</param>
        /// <param name="totalPrice">Total price</param>
        internal static void UpdateDeliveryOrderTotalPrice(
            FoodDeliveryDbContext context,
            DeliveryOrder deliveryOrder,
            decimal totalPrice)
        {
            deliveryOrder.ProductsPrice = (decimal)totalPrice;
            context.SaveChanges();
        }
    }
}
