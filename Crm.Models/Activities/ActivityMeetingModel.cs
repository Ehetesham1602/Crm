using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models.Activities
{
    public class ActivityMeetingModel
    {
        public int Id { get; set; }
        public string MeetingSubject { get; set; }
        public string MeetingDescription { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingTime { get; set; }
        public int EntityId { get; set; }
        public Constants.EntityMasterId EntityMasterId { get; set; }
        public string DescriptionHtml { get; set; }
        public int UserId { get; set; }
    }
}
