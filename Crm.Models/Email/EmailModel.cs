using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Models.Email
{
    public class EmailModel
    {
        public String Host { get; set; }
        public String Port { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String SenderName { get; set; }
        public String SenderEmail { get; set; }
        public String AdminEmail { get; set; }
    }
}
