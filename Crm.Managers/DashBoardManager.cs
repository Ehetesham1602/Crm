using Crm.Dtos.DashBoard;
using Crm.Dtos.Lead;
using Crm.Dtos.User;
using Crm.Dtos.UserLogin;
using Crm.Entities;
using Crm.Factories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Crm.Utilities.Constants;

namespace Crm.Managers
{
    public class DashBoardManager : IDashBoardManager
    {

        private readonly IDashBoardRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public DashBoardManager(IHttpContextAccessor contextAccessor,
          IDashBoardRepository repository,
          IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AgentActiveInActiveDto> GetAgentActivity()
        {
            AgentActiveInActiveDto agentActiveInActiveDtoObj = new AgentActiveInActiveDto();
            List<UserDetailDto> active = await _repository.GetAgentActive();
            List<UserDetailDto> inactive = await _repository.GetAgentInActive();
            agentActiveInActiveDtoObj.Active = active.Count();
            agentActiveInActiveDtoObj.InActive = inactive.Count();

            return agentActiveInActiveDtoObj;

        }
        public async Task<LeadActivityDto> GetLeadActivity()
        {
            string[] leadMonth = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec " };
            List<LeadDto> leads = await _repository.GetLead();
            LeadActivityDto leadActivityDto = new LeadActivityDto();
            leadActivityDto.LeadCount = new List<int>();
            for (var i = 1; i <= leadMonth.Length; i++)
            {
                List<LeadDto> months = await _repository.GetAllMonth(i);
                leadActivityDto.LeadCount.Add(months.Count());
            }
            return leadActivityDto;
        }
        public async Task<AgentDashBoardDto> GetTodaysCallStatistics(int id)
        {
            AgentDashBoardDto agentDashBoardDtoObj = new AgentDashBoardDto();
            List<LeadDto> callDone = await _repository.GetCallDone(id);
            List<LeadDto> callRemainig = await _repository.GetCallRemaining(id);
            agentDashBoardDtoObj.CallDone = callDone.Count();
            agentDashBoardDtoObj.CallRemaining = callRemainig.Count();

            return agentDashBoardDtoObj;

        }
        public async Task<CallStatisticsDto> GetAllCallStatistics()
        {
            string[] callMonth = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec " };
            List<LeadDto> leads = await _repository.GetLead();
            CallStatisticsDto callStatisticsDto = new CallStatisticsDto();
            callStatisticsDto.Call = new List<int>();
            for (var i = 1; i <= callMonth.Length; i++)
            {
                List<LeadDto> months = await _repository.GetAllCallMonth(i);
                callStatisticsDto.Call.Add(months.Count());
            }
            return callStatisticsDto;
        }
    }
}
