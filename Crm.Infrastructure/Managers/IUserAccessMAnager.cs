﻿using Crm.Dtos.UserAccess;
using Crm.Models.UserAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface IUserAccessMAnager
    {
        Task AddUserScreenAccessAsync(List<ScreenAccessModel> model);
        Task<List<ScreenAccessDto>> GetUserScreenAccessById(int id);
        Task<List<ScreendetailDto>> GetAllScreenDetail();
    }
}
