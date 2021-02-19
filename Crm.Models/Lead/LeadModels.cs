using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Crm.Utilities.Constants;

namespace Crm.Models.Lead
{
    public class LeadModels
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Mobile { get; set; }
        public string CompanyName { get; set; }
        public int? ExternalId { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public string Phone { get; set; }
        public int? UserId { get; set; }
        public LeadCallStatus CallStatus { get; set; }
    }
}
