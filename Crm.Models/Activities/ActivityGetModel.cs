using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models.Activities
{
    public class ActivityGetModel
    {
        public int EntityId { get; set; }
        public Constants.EntityMasterId EntityMasterId { get; set; }
    }
}
