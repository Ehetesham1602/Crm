using System;
using System.Collections.Generic;
using System.Text;
using AccountErp.Dtos.Address;
using Crm.Dtos.LeadSource;
using Crm.Dtos.LeadStatus;
using Crm.Utilities;

namespace Crm.Dtos.Lead
{
    public class LeadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Mobile { get; set; }
        public int LeadSourceId { get; set; }
        public int LeadStatusId { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public LeadSourceDetailDto LeadSource { get; set; }
        public LeadStatusDetailDto LeadStatus { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public AddressDto Address { get; set; }
        public string Phone { get; set; }

    }
}
