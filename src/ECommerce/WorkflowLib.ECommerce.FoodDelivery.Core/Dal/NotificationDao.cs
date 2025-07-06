using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.Customers;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    public static class NotificationDao
    {
        /// <summary>
        /// Save notifications.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="notifications"></param>
        public static void SaveNotifications(
            FoodDeliveryDbContext context,
            IEnumerable<Notification> notifications)
        {
            context.Notifications.AddRange(notifications);
            context.SaveChanges();
        }
    }
}
