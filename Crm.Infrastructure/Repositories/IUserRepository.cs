using Crm.Dtos.UserLogin;
using Crm.Entities;
using Crm.Models.UserLogin;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User entity);

        void Edit(User entity);

        Task<User> GetAsync(int id);

        Task<UserDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model);

        Task DeleteAsync(int id);
        Task<UserDetailDto> GetByUserAsync(string username);
        Task<UserDetailDto> Login(UserLoginModel model);
        Task<JqDataTableResponse<UserDetailDto>> GetAgentPagedResultAsync(JqDataTableRequest model);

    }
}
