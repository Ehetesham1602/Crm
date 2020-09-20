using Crm.Dtos.LeadSource;
using Crm.Factories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Models.LeadSource;
using Crm.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Managers
{
    public class LeadSourceManager: ILeadSourceManager
    {
        private readonly ILeadSourceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public LeadSourceManager(IHttpContextAccessor contextAccessor,
          ILeadSourceRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(LeadSourceAddModel model)
        {
            await _repository.AddAsync(LeadSourceFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(LeadSourceEditModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            LeadSourceFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<LeadSourceDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }

        public async Task<JqDataTableResponse<LeadSourceDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<LeadSourceDetailDto>> GetAllSource()
        {
            return await _repository.GetAllSource();
        }
    }
}
