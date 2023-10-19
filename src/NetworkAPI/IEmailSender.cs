using System.Threading.Tasks;
using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.NetworkAPIs
{
    /// <summary>
    /// Email sender interface.
    /// </summary>
    public interface IEmailSender
    {
        void SendEmail(MessageWF message);
        Task SendEmailAsync(MessageWF message);
    }
}