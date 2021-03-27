using Crm.Dtos.UserLogin;
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
        public static User Create(UserLoginDto model, string userId)
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
                Extention_no=model.Extention_no,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }
        public static void Create(UserRegistrationEditModel model, User entity, string userId)
        {
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.UserName = model.UserName;
            entity.Email = model.Email;
            entity.RoleId = model.RoleId;
            entity.Extention_no = model.Extention_no;
          //  entity.Password = Utility.Encrypt(model.Password);
            entity.Mobile = model.Mobile;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }


        public static LoginModule Login(UserDetailDto model)
        {
            var data = new LoginModule
            {
                UserId = model.Id,
                status = true,
                createdOn = Utility.GetDateTime(),
                RoleId = model.RoleId
            };
            return data;
        }

        public static void ChangePassword(UserChangePasswordModel model, User entity, string userId)
        {

            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.Password = Utility.Encrypt(model.Password);

        }
    }
}
