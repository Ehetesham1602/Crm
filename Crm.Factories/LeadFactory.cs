using AccountErp.Entities;
using Crm.Entities;
using Crm.Models.Lead;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Dtos.Lead;
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
                Mobile = model.Mobile,
                LeadSourceId = model.LeadSourceId,
                LeadStatusId = model.LeadStatusId,
                Status = Constants.RecordStatus.Active,
                Phone = model.Phone,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                Address =  new Address
                {
                    CountryId = model.Address.CountryId,
                    StateId = model.Address.StateId,
                    CityId = model.Address.CityId,
                    PostalCode = model.Address.PostalCode,
                    StreetName = model.Address.StreetName
                }
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
            entity.Phone = model.Phone;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            
            //if (!model.Address.Id.HasValue && model.Address.IsAllNullOrEmpty())
            //{
            //    return;
            //}

            if (entity.Address != null)
            {
                entity.Address.CountryId = model.Address.CountryId;
                entity.Address.StateId = model.Address.StateId;
                entity.Address.CityId = model.Address.CityId;
                entity.Address.PostalCode = model.Address.PostalCode;
                entity.Address.StreetName = model.Address.StreetName;
            }
        }

       

        public static Lead CreateLead(LeadModels model, string userId)
        {
            var lead = new Lead
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Website = model.Website,
                Mobile = model.Mobile,
                Status = Constants.RecordStatus.Active,
                Phone = model.Phone,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                CallStatus = Constants.LeadCallStatus.NotDone
            };
            return lead;
        }
        public static void updateLead(LeadDto model, Lead entity,String userId)
        {
            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.Website = model.Website;
            entity.Mobile = model.Mobile;
            entity.Phone = model.Phone;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.UserId = model.UserId;
            entity.CallStatus = model.CallStatus;
            entity.CreatedBy = userId ?? "0";
            entity.CreatedOn = Utility.GetDateTime();
        }
        public static void UpdateCallStatusAsync(LeadDto model, Lead entity, string userId)
        {
            entity.Id = model.Id;
            entity.CallStatus = model.CallStatus;
            entity.CreatedBy = userId ?? "0";
            entity.CreatedOn = Utility.GetDateTime();
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }
    }
}
