using Crm.Dtos.UserAccess;
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
        Task<List<ScreenAccessDto>> GetAsyncUserScreenAccess(Guid id);
        Task DeleteAsyncUserScreenAccess(Guid id);
        Task<List<ScreendetailDto>> GetAllScreenDetail();
    }
}
