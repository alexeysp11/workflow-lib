using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Shared.Models.Business.Customers;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.Dal;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.Handlers
{
    /// <summary>
    /// Backend service controller that allows to send notifications to the users of the system.
    /// </summary>
    public class NotificationsHandler
    {
        private DbContextOptions<FoodDeliveryDbContext> _contextOptions { get; set; }

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public NotificationsHandler(
            DbContextOptions<FoodDeliveryDbContext> contextOptions) 
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// The method that is responsible for sending notifications to system users.
        /// </summary>
        public string SendNotifications(IEnumerable<Notification> notifications)
        {
            string response = "";
            Console.WriteLine("NotificationsBackend.SendNotifications: begin");
            try
            {
                using var context = new FoodDeliveryDbContext(_contextOptions);
                
                // Save notifications.
                NotificationDao.SaveNotifications(context, notifications);

                // Send notifications.
                foreach (var notification in notifications)
                {
                    // Send email.
                    // SendEmail();

                    // Send push notifications.
                    SendPush(notification);

                    // Send message via Telegram.
                    // SendMsgTelegram();
                }
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            Console.WriteLine("NotificationsBackend.SendNotifications: end");
            return response;
        }

        /// <summary>
        /// The method that is responsible for sending email notifications.
        /// </summary>
        public string SendEmail()
        {
            // 
            return "";
        }

        /// <summary>
        /// A basic method that allows you to send push notifications to the user.
        /// </summary>
        public string SendPush(Notification notification)
        {
            string response = "";
            try
            {
                response = "notification is sent";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                Console.WriteLine("ERROR : " + ex.ToString());
            }
            return response;
        }

        /// <summary>
        /// A method that allows you to notify users by sending messages to Telegram.
        /// </summary>
        public string SendMsgTelegram()
        {
            // 
            return "";
        }

        /// <summary>
        /// The method that is responsible for receiving notifications via the REST API.
        /// </summary>
        public string GetNotified()
        {
            // Preprocess.
            // Update DB.
            // Send HTTP request to backend service.
            
            // 
            return "";
        }
    }
}