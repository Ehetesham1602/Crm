using Crm.Entities;
using Crm.Models.UserLogin;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Factories
{
    public class UserFactory
    {
        public static User Create(UserRegistrationModel model, string userId)
        {
            var data = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                Password = Utility.Encrypt(model.Password),
                Mobile = model.Mobile,
                RoleId = model.RoleId,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }
        public static void Create(UserRegistrationModel model, User entity, string userId)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.UserName = model.UserName;
            entity.Email = model.Email;
            entity.RoleId = model.RoleId;
          //  entity.Password = Utility.Encrypt(model.Password);
            entity.Mobile = model.Mobile;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }
    }
}
