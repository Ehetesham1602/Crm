using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Dtos.LeadAssign
{
    public class LeadAssignMainDto
    {
        public List<LeadAssignDto> leadAssignDtosList { get; set; }
        public int LeadTotalCount { get; set; }
        public int TotalCount { get; set; }
    }
}
