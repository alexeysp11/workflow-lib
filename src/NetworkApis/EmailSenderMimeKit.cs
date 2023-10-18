using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.NetworkApis
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailSenderMimeKit : IEmailSender
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly EmailConfiguration _emailConfig;

        /// <summary>
        /// 
        /// </summary>
        public EmailSenderMimeKit(EmailConfiguration emailConfig)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (env.ToLower() == "development")
            {
                _emailConfig = emailConfig;
            }
            else
            {
                emailConfig.From = Environment.GetEnvironmentVariable("EmailConfiguration:From");
                emailConfig.SmtpServer = Environment.GetEnvironmentVariable("EmailConfiguration:SmtpServer");
                emailConfig.Port = Int32.Parse(Environment.GetEnvironmentVariable("EmailConfiguration:Port"));
                emailConfig.UserName = Environment.GetEnvironmentVariable("EmailConfiguration:Username");
                emailConfig.Password = Environment.GetEnvironmentVariable("EmailConfiguration:Password");
                _emailConfig = emailConfig;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendEmail(MessageWF message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task SendEmailAsync(MessageWF message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        private MimeMessage CreateEmailMessage(MessageWF message)
        {
            var emailMessage = new MimeMessage();
            //emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Body) };

            if (message.AttachmentsHttpRequest != null && message.AttachmentsHttpRequest.Any())
            {
                byte[] fileBytes;
                foreach (var attachment in message.AttachmentsHttpRequest)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }
            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}