using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.Extensions;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;
using VelocipedeUtils.Shared.Models.Business.Cooking;
using VelocipedeUtils.Shared.Models.Business.Delivery;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;
using VelocipedeUtils.Shared.Models.Business.Monetary;
using VelocipedeUtils.Shared.Models.Business.Processes;
using VelocipedeUtils.Shared.Models.Business.Products;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.Dal
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
        /// Create delivery order by initial order.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="initialOrderId">Initial order ID</param>
        /// <param name="customerUid">Customer UID</param>
        /// <param name="customerFullName">Customer full name</param>
        /// <returns></returns>
        public static DeliveryOrder CreateDeliveryOrderInitial(
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
                DateStartActual = DateTime.UtcNow
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

        /// <summary>
        /// Get the products that should be delivered.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrderId">Delivery order ID</param>
        /// <returns></returns>
        public static List<DeliveryOrderProduct> GetDeliveryOrderProducts(
            FoodDeliveryDbContext context,
            long deliveryOrderId,
            bool excludeNullProducts = false)
        {
            return context.DeliveryOrderProducts
                .Include(x => x.Product)
                .Include(x => x.DeliveryOrder)
                .Where(x => x.DeliveryOrder != null && x.DeliveryOrder.Id == deliveryOrderId)
                .Where(x => !excludeNullProducts || x.Product != null)
                .ToList();
        }

        /// <summary>
        /// Create delivery order on warehouse.
        /// </summary>
        public static DeliveryOrder? CreateDeliveryOrderOnWh(
            FoodDeliveryDbContext context,
            DeliveryOrder deliveryOrder,
            Employee whEmployee,
            Employee courierEmployee)
        {
            var isSufficient = true;

            var deliveryOrderStore2Wh = new DeliveryOrder
            {
                Uid = Guid.NewGuid().ToString(),
                ParentDeliveryOrder = DeliveryOrderDao.GetDeliveryOrderById(context, deliveryOrder.Id),
                CustomerUid = whEmployee.Uid,
                CustomerName = whEmployee.FullName,
                OrderCustomerType = OrderCustomerType.Employee,
                ExecutorUid = courierEmployee.Uid,
                ExecutorName = courierEmployee.FullName,
                OrderExecutorType = OrderExecutorType.Employee,
                Destination = deliveryOrder.Origin,
                DateStartActual = DateTime.UtcNow
            };

            // Find corresponding records in the DeliveryOrderProduct table by order ID (a table of associations between 
            // the Product, DeliveryOrder and Quantity).
            List<DeliveryOrderProduct> deliveryOrderProducts = GetDeliveryOrderProducts(
                context,
                deliveryOrder.Id);
            List<long> productIds = (from product in deliveryOrderProducts select product.Product.Id).ToList();

            // Using the product IDs from the Product order, find the corresponding records in the Ingredients table (look 
            // at the link to the object FinalProduct).
            List<Ingredient> ingredients = IngredientDao.GetIngredientsByMulipleFinalProductIds(context, productIds);
            List<long> ingredientProductIds = (from ingredient in ingredients select ingredient.IngredientProduct.Id).ToList();

            var deliveryOrderProductsStore2Wh = new List<DeliveryOrderProduct>();
            List<WHProduct> whIngredients = context.WHProducts
                .Include(x => x.Product)
                .Where(x => ingredientProductIds.Any(pid => pid == x.Product.Id))
                .ToList();
            foreach (var whIngredient in whIngredients)
            {
                Ingredient? ingredient = ingredients.FirstOrDefault(x => x.IngredientProduct.Id == whIngredient.Product.Id);
                if (ingredient == null)
                    throw new Exception("Specified ingredient does not exist in the collection");

                DeliveryOrderProduct? deliveryOrderProduct = deliveryOrderProducts.FirstOrDefault(x => x.Product.Id == ingredient.FinalProduct.Id);
                if (deliveryOrderProduct == null)
                    throw new Exception("Specified IngredientProduct does not exist in the DeliveryOrderProducts collection");

                var qtyDelta = deliveryOrderProduct.Quantity * ingredient.Quantity;
                var productTransfer = new ProductTransfer
                {
                    Uid = Guid.NewGuid().ToString(),
                    WHProduct = whIngredient,
                    DeliveryOrderProduct = deliveryOrderProduct,
                    DeliveryOrder = deliveryOrderProduct.DeliveryOrder,
                    Date = DateTime.UtcNow,
                    OldQuantity = whIngredient.Quantity,
                    NewQuantity = whIngredient.Quantity - qtyDelta,
                    QuantityDelta = qtyDelta
                };
                whIngredient.Quantity = (int)productTransfer.NewQuantity;
                if (whIngredient.Quantity < whIngredient.MinQuantity)
                {
                    isSufficient = false;
                    var whingredientLimits = new List<int> { whIngredient.MinQuantity, whIngredient.MaxQuantity };
                    var deliveryOrderProductStore2Wh = new DeliveryOrderProduct
                    {
                        Uid = Guid.NewGuid().ToString(),
                        Product = whIngredient.Product,
                        DeliveryOrder = deliveryOrderStore2Wh,
                        Quantity = (int)whingredientLimits.Average() - whIngredient.Quantity
                    };
                    deliveryOrderProductsStore2Wh.Add(deliveryOrderProductStore2Wh);
                }
                context.ProductTransfers.Add(productTransfer);
            }
            
            // If the amount of ingredients is not sufficient on the warehouse, create a record for delivering from store to WH.
            if (!isSufficient)
            {
                deliveryOrderStore2Wh.ProductsPrice = deliveryOrderProductsStore2Wh.Sum(x => x.Product.Price * x.Quantity);
                context.DeliveryOrders.Add(deliveryOrderStore2Wh);
                context.DeliveryOrderProducts.AddRange(deliveryOrderProductsStore2Wh);
            }

            context.SaveChanges();

            return isSufficient ? null : deliveryOrderStore2Wh;
        }

        /// <summary>
        /// Get delivery order by its ID.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrderId">Delivery order ID</param>
        /// <returns></returns>
        public static DeliveryOrder? GetDeliveryOrderById(FoodDeliveryDbContext context, long deliveryOrderId)
        {
            return context.DeliveryOrders.FirstOrDefault(x => x.Id == deliveryOrderId);
        }

        /// <summary>
        /// Change delivery order status.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrder">Delivery order</param>
        /// <param name="status"></param>
        public static void ChangeDeliveryOrderStatus(
            FoodDeliveryDbContext context,
            DeliveryOrder deliveryOrder,
            OrderStatus status)
        {
            deliveryOrder.Status = EnumExtensions.GetDisplayName(status);
            context.SaveChanges();
        }

        /// <summary>
        /// Get parent delivery order by delivery order ID.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="deliveryOrderId">Delivery order ID</param>
        /// <returns></returns>
        public static DeliveryOrder? GetParentDeliveryOrderById(FoodDeliveryDbContext context, long deliveryOrderId)
        {
            return context.DeliveryOrders
                .Where(x => x.Id == deliveryOrderId)
                .Select(x => x.ParentDeliveryOrder)
                .FirstOrDefault();
        }

        /// <summary>
        /// Get business tasks from DbSet of <see cref="BusinessTaskDeliveryOrder"/> elements.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="deliveryOrderId"></param>
        /// <returns></returns>
        public static List<BusinessTask?> GetBusinessTaskDeliveryOrders(
            FoodDeliveryDbContext context,
            long deliveryOrderId)
        {
            return context.BusinessTaskDeliveryOrders
                .Where(x => x.DeliveryOrder != null && x.DeliveryOrder.Id == deliveryOrderId && x.BusinessTask != null)
                .Select(x => x.BusinessTask)
                .ToList();
        }
    }
}
