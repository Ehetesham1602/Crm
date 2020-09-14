using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class LeadStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
