using Crm.Dtos.UserLogin;
using Crm.Models.UserLogin;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface IUserManager
    {
        Task AddAsync(UserRegistrationModel model);

        Task EditAsync(UserRegistrationModel model);

        Task<UserDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
        Task<UserDetailDto> CheckUser(string username);
        Task<UserDetailDto> Login(UserLoginModel model);
    }
}
