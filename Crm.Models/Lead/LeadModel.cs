using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crm.Models.Lead
{
    public class LeadModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Mobile { get; set; }
        public int? LeadSourceId { get; set; }
        public int? LeadStatusId { get; set; }
        public string CompanyName { get; set; }
        public int? ExternalId { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public AddressModel Address { get; set; }
        public string Phone { get; set; }

    }
}
