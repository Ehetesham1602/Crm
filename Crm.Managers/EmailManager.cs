using AccountErp.Infrastructure.Managers;
using Crm.Infrastructure.Services;
using Crm.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailServiceSendLeadAsync _emailService;

        public EmailManager(IEmailServiceSendLeadAsync emailService)
        {
            _emailService = emailService;
        }

        //public async Task SendLeadAsync(string email,string attachmentPath)
        public async Task SendLeadAsync(string email, EmailLeadModel model)
        {
            await _emailService.SendWithAttachmentAsync(email ,model.Subject,model.Html );
        }
    }
}
