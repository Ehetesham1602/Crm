using Crm.Dtos.UserLogin;
using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Crm.Utilities;
using Crm.Infrastructure.Repositories;
using Crm.Models.UserLogin;

namespace Crm.DataLayer.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(User entity)
        {
            await _dataContext.User.AddAsync(entity);
        }

        public void Edit(User entity)
        {
            _dataContext.User.Update(entity);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _dataContext.User.FindAsync(id);
        }

        public async Task<UserDetailDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.User
                          where s.Id == id
                          select new UserDetailDto
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              UserName = s.UserName,
                              Password =s.Password,
                              Mobile = s.Mobile,
                              Email = s.Email,
                              RoleId = s.RoleId,
                              RoleName = s.Role.RoleName
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.User
                            where s.Status != Constants.RecordStatus.Deleted && (model.filterKey == null || EF.Functions.Like(s.FirstName, "%" + model.filterKey + "%")
                            || EF.Functions.Like(s.LastName, "%" + model.filterKey + "%"))
                            select new UserDetailDto
                            {
                                Id = s.Id,
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                UserName = s.UserName,
                                Password = s.Password,
                                Mobile = s.Mobile,
                                Email = s.Email,
                                RoleId = s.RoleId,
                                RoleName = s.Role.RoleName
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<UserDetailDto>
            {
                RecordsTotal = await _dataContext.User.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.User.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.User.Update(data);
        }

        public async Task<UserDetailDto> GetByUserAsync(string username)
        {
            return await (from s in _dataContext.User
                          where s.UserName == username
                          select new UserDetailDto
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              UserName = s.UserName,
                              Password = s.Password,
                              Mobile = s.Mobile,
                              Email = s.Email,
                              RoleId = s.RoleId,
                              RoleName = s.Role.RoleName
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
        public async Task<UserDetailDto> Login(UserLoginModel model)
        {
            return await (from s in _dataContext.User
                          where s.UserName == model.UserName && s.Password == Utility.Encrypt(model.Password)
                          select new UserDetailDto
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              UserName = s.UserName,
                              Password = s.Password,
                              Mobile = s.Mobile,
                              Email = s.Email,
                              RoleId = s.RoleId,
                              RoleName = s.Role.RoleName
                          })
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }
        public async Task<JqDataTableResponse<UserDetailDto>> GetAgentPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.User
                            where s.Role.RoleName == "Agent"  && s.Status != Constants.RecordStatus.Deleted && (model.filterKey == null || EF.Functions.Like(s.FirstName, "%" + model.filterKey + "%")
                            || EF.Functions.Like(s.LastName, "%" + model.filterKey + "%"))
                            select new UserDetailDto
                            {
                                Id = s.Id,
                                FirstName = s.FirstName,
                                LastName = s.LastName,
                                UserName = s.UserName,
                                Password = s.Password,
                                Mobile = s.Mobile,
                                Email = s.Email,
                                RoleId = s.RoleId,
                                RoleName = s.Role.RoleName
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<UserDetailDto>
            {
                RecordsTotal = await _dataContext.User.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }
    }
}
