using System.Threading.Tasks;
using WorkflowLib.Models.Business.SocialCommunication;

namespace WorkflowLib.NetworkAPIs
{
    /// <summary>
    /// Email sender interface.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Send email.
        /// </summary>
        void SendEmail(MessageWF message);

        /// <summary>
        /// Send email asynchronously.
        /// </summary>
        Task SendEmailAsync(MessageWF message);
    }
}