using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Dtos.Activities
{
    public class ActivityTaskDetailDto
    {
        public int Id { get; set; }
        public string TaskSubject { get; set; }
        public string TaskDescription { get; set; }
        public string TaskPurpose { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskTime { get; set; }
        public int EntityId { get; set; }
        public Constants.EntityMasterId EntityMasterId { get; set; }
        public string DescriptionHtml { get; set; }
        public int UserId { get; set; }
    }
}
