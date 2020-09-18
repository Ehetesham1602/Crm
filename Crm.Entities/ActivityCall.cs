﻿using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class ActivityCall
    {
        public int Id { get; set; }
        public string CallSubject { get; set; }
        public string CallDescription { get; set; }
        public string CallPurpose { get; set; }
        public DateTime CallDate { get; set; }
        public string CallTime { get; set; }
        public int EntityId { get; set; }
        public Constants.EntityMasterId EntityMasterId { get; set; }
        public string DescriptionHtml { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}