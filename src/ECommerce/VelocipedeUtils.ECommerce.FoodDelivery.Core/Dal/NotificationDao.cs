using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.Shared.Models.Business.Customers;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.Dal
{
    public static class NotificationDao
    {
        /// <summary>
        /// Save notifications.
        /// </summary>
        /// <param name="context">Database context</param>
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
