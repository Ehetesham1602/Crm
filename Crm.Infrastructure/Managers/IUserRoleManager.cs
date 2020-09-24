using Crm.Dtos;
using Crm.Dtos.UserLogin;
using Crm.Models.UserLogin;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface IUserRoleManager
    {
        Task AddAsync(UserRoleModel model);

        Task EditAsync(UserRoleModel model);

        Task<UserRoleDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<UserRoleDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
        Task<List<SelectListItemDto>> GetAllAsync();
    }
}
