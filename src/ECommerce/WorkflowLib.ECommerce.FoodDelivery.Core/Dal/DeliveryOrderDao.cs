using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Extensions;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Delivery;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Shared.Models.Business.Monetary;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    /// <summary>
    /// Food delivery DAO.
    /// </summary>
    public static class DeliveryOrderDao
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
        public static float? GetDeliveryOrderTotalPrice(FoodDeliveryDbContext context, long deliveryOrderId)
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
        public static void UpdateDeliveryOrderTotalPrice(
            FoodDeliveryDbContext context,
            DeliveryOrder deliveryOrder,
            decimal totalPrice)
        {
            deliveryOrder.ProductsPrice = (decimal)totalPrice;
            context.SaveChanges();
        }

        /// <summary>
        /// Create delivery order.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customerFullName"></param>
        /// <param name="receiverName"></param>
        /// <returns></returns>
        public static DeliveryOrder CreateDeliveryOrder(
            FoodDeliveryDbContext context,
            long initialOrderId,
            string? customerUid,
            string? customerFullName)
        {
            // Get initial order by ID.
            InitialOrder? existedInitialOrder = InitialOrderDao.GetInitialOrderById(context, initialOrderId);
            if (existedInitialOrder == null)
                throw new Exception("Specified initial order does not exist in the database");

            // Get organization.
            Organization? organization = OrganizationDao.GetOrganization(context);
            if (organization == null || organization.Company == null)
                throw new Exception("Organization or company is not defined");
            if (string.IsNullOrEmpty(organization.Company.Address))
                throw new Exception("Address of the company is not specified");

            // Create delivery order.
            DeliveryOrder deliveryOrder = new DeliveryOrder
            {
                Uid = Guid.NewGuid().ToString(),
                Payments = new List<Payment>
                {
                    new Payment
                    {
                        Uid = Guid.NewGuid().ToString(),
                        PaymentType = existedInitialOrder.PaymentType,
                        PaymentMethod = existedInitialOrder.PaymentMethod,
                        Amount = existedInitialOrder.PaymentAmount,
                        Payer = customerFullName,
                        Receiver = string.IsNullOrEmpty(organization.Company.Name) ? "Our company" : organization.Company.Name,
                        Status = EnumExtensions.GetDisplayName(PaymentStatus.Requested)
                    }
                },
                CustomerUid = customerUid,
                CustomerName = customerFullName,
                OrderCustomerType = OrderCustomerType.Customer,
                ExecutorUid = organization.Company.Uid,
                ExecutorName = organization.Company.Name,
                OrderExecutorType = OrderExecutorType.Company,
                Origin = organization.Company.Address,
                Destination = existedInitialOrder.Address,
                DateStartActual = DateTime.Now
            };
            context.DeliveryOrders.Add(deliveryOrder);
            context.Payments.AddRange(deliveryOrder.Payments);

            // Create order products.
            List<InitialOrderProduct> initialOrderProducts = context.InitialOrderProducts
                .Include(x => x.Product)
                .Where(x => x.InitialOrder != null && x.InitialOrder.Id == initialOrderId)
                .ToList();
            foreach (var iop in initialOrderProducts)
            {
                var deliveryOrderProduct = new DeliveryOrderProduct
                {
                    Uid = Guid.NewGuid().ToString(),
                    Product = iop.Product,
                    DeliveryOrder = deliveryOrder,
                    Quantity = iop.Quantity
                };
                context.DeliveryOrderProducts.Add(deliveryOrderProduct);
            }
            
            // Update price.
            deliveryOrder.ProductsPrice = existedInitialOrder.PaymentAmount;
            deliveryOrder.TotalPrice = existedInitialOrder.PaymentAmount;
            
            // Bind delivery order and initial order.
            existedInitialOrder.DeliveryOrderId = deliveryOrder.Id;
            
            context.SaveChanges();

            return deliveryOrder;
        }
    }
}
