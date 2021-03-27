﻿using Crm.Dtos.UserLogin;
using Crm.Factories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Models.UserLogin;
using Crm.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public UserManager(IHttpContextAccessor contextAccessor,
          IUserRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(UserLoginDto model)
        {
            await _repository.AddAsync(UserFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task LoginAddAsync(UserDetailDto model)
        {
            await _repository.LoginAddAsync(UserFactory.Login(model));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(UserRegistrationEditModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            UserFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ChangePassword(UserChangePasswordModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            UserFactory.ChangePassword(model, item, _userId);
            _repository.ChangePassword(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }

        public async Task<JqDataTableResponse<UserDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<UserDetailDto> CheckUser(string username)
        {
            return await _repository.GetByUserAsync(username);
        }
        public async Task<UserDetailDto> Login(UserLoginModel model)
        {
            return await _repository.Login(model);
        }
        public async Task<JqDataTableResponse<UserDetailDto>> GetAgentPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetAgentPagedResultAsync(model);
        }

        public async Task LogOut(int id)
        {
           await _repository.LogOut(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<JqDataTableResponse<UserDetailDto>> GetOnlineAgentPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetOnlineAgentPagedResultAsync(model);
        }

        public async Task<JqDataTableResponse<UserDetailDto>> GetOnlyOnlineAgentPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetOnlyOnlineAgentPagedResultAsync(model);
        }

    }
}