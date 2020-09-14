using Crm.Dtos.LeadStatus;
using Crm.Factories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Models.LeadStatus;
using Crm.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Managers
{
    public class LeadStatusManager : ILeadStatusManager
    {
        private readonly ILeadStatusRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public LeadStatusManager(IHttpContextAccessor contextAccessor,
          ILeadStatusRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(LeadStatusAddModel model)
        {
            await _repository.AddAsync(LeadStatusFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(LeadStatusEditModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            LeadStatusFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<LeadStatusDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }

        public async Task<JqDataTableResponse<LeadStatusDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsync(model);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
