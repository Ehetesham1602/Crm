using Crm.Dtos;
using Crm.Dtos.UserLogin;
using Crm.Entities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface IUserRoleRepository
    {
        Task AddAsync(UserRole entity);

        void Edit(UserRole entity);

        Task<UserRole> GetAsync(int id);

        Task<UserRoleDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<UserRoleDetailDto>> GetPagedResultAsync(JqDataTableRequest model);

        Task DeleteAsync(int id);
        Task<List<SelectListItemDto>> GetAllAsync();
    }
}
