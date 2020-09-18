using Crm.Dtos.Lead;
using Crm.Factories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Models.Lead;
using Crm.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Managers
{
    public class LeadManager : ILeadManager
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public LeadManager(IHttpContextAccessor contextAccessor,
            ILeadRepository repository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _leadRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(LeadModel model)
        {
            await _leadRepository.AddAsync(LeadFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditAsync(LeadModel model)
        {
            var lead = await _leadRepository.GetAsync(model.Id);
            LeadFactory.Create(model, lead, _userId);
            _leadRepository.Edit(lead);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _leadRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<JqDataTableResponse<LeadDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _leadRepository.GetPagedResultAsync(model);
        }
    }
}
