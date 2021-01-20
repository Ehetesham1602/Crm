using Crm.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
    public interface IEmailManager
    {
        //Task SendInvoAsync(string email, string attachmentPath);
       // Task SendLeadAsync(string email, string completePath, EmailLeadModel model);
        Task SendLeadAsync(string email, EmailLeadModel model, string completePath);
    }
}
