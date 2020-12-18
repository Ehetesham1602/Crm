using AccountErp.Entities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Mobile { get; set; }
        public int? LeadSourceId { get; set; }
        public int? LeadStatusId { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public LeadSource LeadSource { get; set; }
        public LeadStatus LeadStatus { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public int? UserId { get; set; }
        public Boolean CallStatus { get; set; }
        public User User { get; set; }
    }
}
