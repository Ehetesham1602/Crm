
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System.IO;
using Microsoft.Extensions.Options;
using AccountErp.Models.Email;
using Crm.Infrastructure.Services;
using System.Security.Authentication;
using MailKit.Security;

namespace AccountErp.Services
{
    public class EmailService : IEmailServiceSendLeadAsync
    {
        private IConfiguration _smtpConfiguration;

        private readonly IOptions<EmailModel> appSettings;
        public EmailService(IOptions<EmailModel> app)
        {
            appSettings = app;
        }
        //public EmailService(IConfiguration configuration)
        //{
        //    _smtpConfiguration = configuration;
        //}

        private async Task SendAsync(MimeMessage message)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                smtpClient.CheckCertificateRevocation = false;
                smtpClient.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Ssl2 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;
              //  smtpClient.Connect(host: IMAP_SERVER, port: IMAP_PORT, options: SecureSocketOptions.SslOnConnect);
                await smtpClient.ConnectAsync(appSettings.Value.Host, Convert.ToInt32(appSettings.Value.Port), options: SecureSocketOptions.SslOnConnect);
                smtpClient.AuthenticationMechanisms.Clear();
                smtpClient.AuthenticationMechanisms.Add("PLAIN");
                await smtpClient.AuthenticateAsync(appSettings.Value.Username, appSettings.Value.Password);
                await smtpClient.SendAsync(message);
                await smtpClient.DisconnectAsync(true);
            }
        }

        public async Task SendAsync(string email, string subject, string mailBody)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(appSettings.Value.SenderName, appSettings.Value.SenderEmail));
            mimeMessage.To.Add(new MailboxAddress(email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new BodyBuilder { HtmlBody = mailBody }.ToMessageBody();

            await SendAsync(mimeMessage);
        }

        public async Task SendAsync(string receiver, string senderName, string senderEmail, string subject, string mailBody)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(senderName ?? appSettings.Value.SenderName, senderEmail ?? appSettings.Value.SenderEmail));
            mimeMessage.To.Add(new MailboxAddress(receiver));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new BodyBuilder { HtmlBody = mailBody }.ToMessageBody();
            await SendAsync(mimeMessage);
        }

       // public async Task SendWithAttachmentAsync(string email, string subject, string mailBody, string path)
        public async Task SendWithAttachmentAsync(string email, string subject, string mailBody, string path)
        {
            //string value = _smtpConfiguration.GetSection("Smtp").GetSection("Smtp").Value;
            var data = appSettings.Value.Port;
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(appSettings.Value.SenderName, appSettings.Value.SenderEmail));
            mimeMessage.To.Add(new MailboxAddress(email));
            mimeMessage.Subject = subject;
            var multipart = new Multipart();
            var body = new TextPart("plain")
            {
                Text = mailBody
            };
            multipart.Add(body);
            if (path != null)
            {
                var attachment = new MimePart("application/pdf")
                {
                    Content = new MimeContent(File.OpenRead(path)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(path)
                };
                 multipart.Add(attachment);
            }
           
            mimeMessage.Body = multipart;
            await SendAsync(mimeMessage);
        }
    }
}
