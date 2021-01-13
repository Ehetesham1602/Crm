using Crm.DataLayer;
using Crm.Dtos.Lead;
using Crm.Dtos.UserLogin;
using Crm.Entities;
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
    public class LeadAssignManager : ILeadAssignManager
    {
        
        private readonly ILeadAssignRepository _leadAssignRepository;
        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;
        private readonly DataContext _dataContext;


        public LeadAssignManager(IHttpContextAccessor contextAccessor,
            ILeadAssignRepository repository, ILeadRepository leadrepository, DataContext dataContext,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _leadRepository = leadrepository;
            _leadAssignRepository = repository;
            _unitOfWork = unitOfWork;
            _dataContext = dataContext;
        }
        public async Task EditAsync(List<LeadDto> leadList)
        {

            foreach (var value in leadList)
            {
                Lead lead = new Lead();
                LeadFactory.updateLead(value, lead, _userId);
               _leadRepository.Edit(lead);
               
            }
            await _unitOfWork.SaveChangesAsync();

        }
        public async Task<List<LeadDto>> GetByAgentIdAsync(int id)
        {
            return await _leadAssignRepository.GetByAgentIdAsync(id);
        }
        /*public async Task UpdateCallStatusAsync(LeadDto leadId)
        {
                Lead lead = new Lead();
                LeadFactory.UpdateCallStatusAsync(leadId, lead, _userId);
                _leadRepository.Edit(lead);
            
            await _unitOfWork.SaveChangesAsync();

        }*/
        public async Task ChangeCallStatusByIdAsync(ChangeCallStatusModel changeCallStatusModel)
        {
            await _leadAssignRepository.ChangeCallStatusByIdAsync(changeCallStatusModel);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
