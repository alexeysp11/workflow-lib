using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Extensions;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    public static class BusinessTaskDao
    {
        /// <summary>
        /// Create business task to deliver from store to warehouse.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="deliveryOrder">Delivery order</param>
        /// <param name="notification">Notification</param>
        public static void CreateStore2WhBusinessTask(
            FoodDeliveryDbContext context,
            DeliveryOrder deliveryOrder,
            Notification notification)
        {
            // Create the business task.
            var businessTask = new BusinessTask
            {
                Uid = Guid.NewGuid().ToString(),
                Name = notification.TitleText,
                Subject = notification.TitleText,
                Description = notification.BodyText,
                Status = BusinessTaskStatus.Open
            };
            context.BusinessTasks.Add(businessTask);

            // Bind the business task with delivery order.
            var businessTaskDeliveryOrder = new BusinessTaskDeliveryOrder
            {
                Uid = Guid.NewGuid().ToString(),
                BusinessTask = businessTask,
                DeliveryOrder = deliveryOrder,
                Discriminator = EnumExtensions.GetDisplayName(BusinessTaskDiscriminator.RequestStore2Wh)
            };
            context.BusinessTaskDeliveryOrders.Add(businessTaskDeliveryOrder);

            context.SaveChanges();
        }

        /// <summary>
        /// Get business task list by delivery order ID.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="deliveryOrderId">Delivery order ID</param>
        /// <param name="taskDiscriminator">Task discriminator</param>
        /// <returns></returns>
        public static List<BusinessTask?> GetBusinessTasksByDeliveryOrderId(
            FoodDeliveryDbContext context,
            long deliveryOrderId,
            BusinessTaskDiscriminator taskDiscriminator)
        {
            return context.BusinessTaskDeliveryOrders
                .Where(x => x.BusinessTask != null
                    && x.DeliveryOrder != null
                    && x.Discriminator == EnumExtensions.GetDisplayName(taskDiscriminator)
                    && x.DeliveryOrder.Id == deliveryOrderId)
                .Select(x => x.BusinessTask)
                .ToList();
        }

        /// <summary>
        /// Close specified business tasks.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="businessTasks">Specified business tasks</param>
        internal static void CloseBusinessTasks(FoodDeliveryDbContext context, List<BusinessTask?> businessTasks)
        {
            if (businessTasks == null || !businessTasks.Any())
            {
                return;
            }

            foreach (var businessTask in businessTasks)
            {
                if (businessTask == null)
                {
                    continue;
                }
                businessTask.Status = BusinessTaskStatus.Closed;
            }
            context.SaveChanges();
        }
    }
}
