using Crm.DataLayer;
using Crm.Dtos.Lead;
using Crm.Dtos.LeadAssign;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Managers
{
    public class LeadAssignManager : ILeadAssignManager
    {

        private readonly ILeadAssignRepository _leadAssignRepository;
        private readonly ILeadRepository _leadRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;
        private readonly DataContext _dataContext;


        public LeadAssignManager(IHttpContextAccessor contextAccessor,
            ILeadAssignRepository repository, IUserRepository userRepository, ILeadRepository leadrepository, DataContext dataContext,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _leadRepository = leadrepository;
            _userRepository = userRepository;
            _leadAssignRepository = repository;
            _unitOfWork = unitOfWork;
            _dataContext = dataContext;
        }
        public async Task EditAsync()
        {
            List<LeadDto> leadList = await _leadAssignRepository.GetAllLead();
            List<UserDetailDto> userList = await _leadAssignRepository.GetAllUser();
            var leadCount = leadList.Count();
            var userCount = userList.Count();
            var size = leadCount / userCount;

            if(userCount > leadCount)
            {
                for (int i = 0; i < leadCount; i++)
                {
                   
                            leadList[i].UserId = userList[i].Id;
                        }
                  
            }
            else
            {
                if (leadCount % 2 != 0)
                {
                    size = size + 1;
                }
                int k = 0;
                for (int i = 0; i <= userCount; i++)
                {
                    for (int j = 0; j <= size; j++)
                    {
                        if (k < leadCount)
                        {
                            leadList[k].UserId = userList[i].Id;
                        }
                        k++;
                    }

                }
            }
           
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
         public async Task<List<LeadAssignDto>> GetLeadAssignInfoAsync()
        {
            List<LeadAssignDto> leadDto = new List<LeadAssignDto>();
            List<LeadDto> leadList = await _leadAssignRepository.GetAllLead();
            List<UserDetailDto> userList = await _leadAssignRepository.GetAllUser();
            var leadCount = leadList.Count();
            var userCount = userList.Count();
            var size = leadCount / userCount;
            if (leadCount % 2 != 0)
            {
                size = size + 1;
            }
            int k = 0;
            for (int i = 0; i <= userCount; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (k < leadCount)
                    {
                        leadList[k].UserId = userList[i].Id;
                    }
                    k++;
                }

            }
            var itemsList = (leadList.GroupBy(l => l.UserId, l => new { l.LastName, l.FirstName })
                            .Select(g => new { GroupId = g.Key, Values = g.ToList() })).ToList();

            foreach (var item in itemsList)
            {
                LeadAssignDto tempLeadDto = new LeadAssignDto();
                tempLeadDto.LeadCount = item.Values.Count();
                var user = await _userRepository.GetAsync(item.GroupId ?? 0);
                if(user != null)
                {
                    tempLeadDto.AgentName = user.FirstName + " " + user.LastName;
                    leadDto.Add(tempLeadDto);

                }


            }
            return leadDto;
        }

    }
}
