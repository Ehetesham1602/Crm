using AccountErp.Entities;
using Crm.Entities;
using Crm.Models.Lead;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Crm.Factories
{
    public class LeadAssignFactory
    {
        public static void AssignUpdate(LeadModels model, Lead entity, User user,  string userId)
        {
            if(userId != null)
            {
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Website = model.Website;
                entity.Mobile = model.Mobile;
                entity.Phone = model.Phone;
                entity.UpdatedBy = userId ?? "0";
                entity.UpdatedOn = Utility.GetDateTime();
            }
            
        }
    }
}
