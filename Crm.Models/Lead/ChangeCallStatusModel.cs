using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models.Lead
{
    public class ChangeCallStatusModel
    {
        public int Id { get; set; }
        public Constants.LeadCallStatus CallStatus { get; set; }
    }
}
