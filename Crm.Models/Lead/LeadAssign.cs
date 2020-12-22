using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crm.Models.Lead
{
    public class LeadAssign
    {
        [Required]
        public int Id { get; set; }
        public bool CallStatus { get; set; }
    }
}
