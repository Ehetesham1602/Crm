using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class LeadSource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Constants.RecordStatus Status { get; set; }
    }
}
