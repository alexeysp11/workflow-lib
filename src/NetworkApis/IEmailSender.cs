using System.Threading.Tasks;
using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.NetworkApis
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmailSender
    {
        void SendEmail(MessageWF message);
        Task SendEmailAsync(MessageWF message);
    }
}