using Crm.Dtos.UserAccess;
using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Crm.Infrastructure.Repositories;

namespace Crm.DataLayer.Repositories
{
    public class UserAccessRepository: IUserAccessRepository
    {
        private readonly DataContext _dataContext;

        public UserAccessRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task AddUserScreenAccessAsync(List<UserScreenAccess> entity)
        {
            foreach (var item in entity)
            {
                await _dataContext.UserScreenAccess.AddAsync(item);
            }

        }

        public async Task<List<ScreenAccessDto>> GetAsyncUserScreenAccess(Guid id)
        {
            return await (from s in _dataContext.UserScreenAccess
                          where s.UserRoleId == id
                          select new ScreenAccessDto
                          {
                              Id = s.Id,
                              ScreenId = s.ScreenId,
                              UserRoleId = s.UserRoleId,
                              CanAccess = s.CanAccess
                          })
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task DeleteAsyncUserScreenAccess(Guid id)
        {
            var data = await _dataContext.UserScreenAccess.Where(x => x.UserRoleId == id).ToListAsync();
            foreach (var item in data)
            {
                _dataContext.UserScreenAccess.Remove(item);
            }

        }

    }
}
