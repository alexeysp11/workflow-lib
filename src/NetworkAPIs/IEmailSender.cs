using System.Threading.Tasks;
using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.NetworkAPIs
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