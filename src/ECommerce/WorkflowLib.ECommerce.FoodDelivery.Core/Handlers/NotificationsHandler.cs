using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Handlers
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
            System.Console.WriteLine("NotificationsBackend.SendNotifications: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("NotificationsBackend.SendNotifications: validation");
                using var context = new FoodDeliveryDbContext(_contextOptions);

                foreach (var notification in notifications)
                {
                    // Update DB.
                    System.Console.WriteLine("NotificationsBackend.SendNotifications: cache");
                    context.Notifications.Add(notification);

                    // Send email.
                    // SendEmail();

                    // Send push notifications.
                    SendPush(notification);

                    // Send message via Telegram.
                    // SendMsgTelegram();
                    
                    // Update DB.
                    System.Console.WriteLine("NotificationsBackend.SendNotifications: cache");
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("NotificationsBackend.SendNotifications: end");
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
            System.Console.WriteLine("NotificationsBackend.SendPush: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("NotificationsBackend.SendPush: validation");
                
                // Update DB.
                System.Console.WriteLine("NotificationsBackend.SendPush: cache");

                // Sending push notification.
                System.Console.WriteLine("NotificationsBackend.SendPush: notifying");
                
                // Update DB.
                System.Console.WriteLine("NotificationsBackend.SendPush: cache");

                // 
                response = "notification is sent";
            }
            catch (Exception ex)
            {
                response = "error: " + ex.Message;
                System.Console.WriteLine("ERROR : " + ex.ToString());
            }
            System.Console.WriteLine("NotificationsBackend.SendPush: end");
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