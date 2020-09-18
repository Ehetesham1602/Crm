using Crm.Entities;
using Crm.Models.Lead;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Factories
{
    public class LeadFactory
    {
        public static Lead Create(LeadModel model, string userId)
        {
            var lead = new Lead
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Website = model.Website,
                Mobile= model.Mobile,
                LeadSourceId = model.LeadSourceId,
                LeadStatusId = model.LeadStatusId,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime()
            };
            return lead;
        }

        public static void Create(LeadModel model, Lead entity, string userId)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Website = model.Website;
            entity.Mobile = model.Mobile;
            entity.LeadSourceId = model.LeadSourceId;
            entity.LeadStatusId = model.LeadStatusId;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }

    }
}
