using Crm.Entities;
using Crm.Models.LeadSource;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Factories
{
    public class LeadSourceFactory
    {
        public static LeadSource Create(LeadSourceAddModel model, string userId)
        {
            var item = new LeadSource
            {
                Name = model.Name,
                Status = Constants.RecordStatus.Active
            };
            return item;
        }
        public static void Create(LeadSourceEditModel model, LeadSource entity, string userId)
        {
            entity.Name = model.Name;
        }
    }
}
