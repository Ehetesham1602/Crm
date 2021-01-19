using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Services
{
    public interface IEmailServiceSendLeadAsync
    {
        Task SendAsync(string email, string subject, string mailBody);
        Task SendAsync(string receiver, string senderName, string senderEmail, string subject, string mailBody);

       //Task SendWithAttachmentAsync(string email, string subject, string mailBody, string path);
        Task SendWithAttachmentAsync(string email, string subject, string mailBody);
    }
}
