﻿using Crm.Dtos.UserAccess;
using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface IUserAccessRepository
    {
        Task AddUserScreenAccessAsync(List<UserScreenAccess> entity);
        Task<List<ScreenAccessDto>> GetAsyncUserScreenAccess(int id);
        Task DeleteAsyncUserScreenAccess(int id);
        Task<List<ScreendetailDto>> GetAllScreenDetail();
    }
}
