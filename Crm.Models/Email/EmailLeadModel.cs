using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models.Email
{
    public class EmailLeadModel
    {
        public int Id { get; set; }
        public string Html { get; set; }

        public string Subject { get; set; }

    }
}
