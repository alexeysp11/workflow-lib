using System.Collections.Generic;
using Cims.WorkflowLib.Example01.Interfaces;
using Cims.WorkflowLib.Example01.Models;
using Cims.WorkflowLib.Models.Business.Customers;

namespace Cims.WorkflowLib.Example01.Controllers
{
    public class NotificationsBackendController : INotificationsBackend
    {
        public string SendNotifications(IEnumerable<Notification> notifications)
        {
            string response = "";
            System.Console.WriteLine("NotificationsBackend.SendNotifications: begin");
            try
            {
                // Validation.
                System.Console.WriteLine("NotificationsBackend.SendNotifications: validation");

                foreach (var notification in notifications)
                {
                    // Update DB.
                    System.Console.WriteLine("NotificationsBackend.SendNotifications: cache");

                    // Send email.
                    // SendEmail();

                    // Send push notifications.
                    SendPush(notification);

                    // Send message via Telegram.
                    // SendMsgTelegram();
                    
                    // Update DB.
                    System.Console.WriteLine("NotificationsBackend.SendNotifications: cache");
                }
            }
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("NotificationsBackend.SendNotifications: end");
            return response;
        }

        public string SendEmail()
        {
            // 
            return "";
        }

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
            catch (System.Exception ex)
            {
                response = "error: " + ex.Message;
            }
            System.Console.WriteLine("NotificationsBackend.SendPush: end");
            return response;
        }

        public string SendMsgTelegram()
        {
            // 
            return "";
        }

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