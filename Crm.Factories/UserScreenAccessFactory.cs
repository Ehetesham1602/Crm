﻿using Crm.Entities;
using Crm.Models.UserAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Factories
{
    public class UserScreenAccessFactory
    {
        public static void CreateUserScreenAccess(List<ScreenAccessModel> model, List<UserScreenAccess> entities)
        {

            foreach (var item in model)
            {
                var data = new UserScreenAccess
                {
                  //  Id = Guid.NewGuid(),
                    UserRoleId = item.UserRoleId,
                    ScreenId = item.ScreenId,
                    CanAccess = item.CanAccess
                };
                entities.Add(data);
            }
        }
    }
}
