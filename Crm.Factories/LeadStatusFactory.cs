using Crm.Entities;
using Crm.Models.LeadStatus;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Factories
{
    public class LeadStatusFactory
    {
        public static LeadStatus Create(LeadStatusAddModel model, string userId)
        {
            var data = new LeadStatus
            {
                Name = model.Name,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }
        public static void Create(LeadStatusEditModel model, LeadStatus entity, string userId)
        {
            entity.Name = model.Name;
        }
    }
}
