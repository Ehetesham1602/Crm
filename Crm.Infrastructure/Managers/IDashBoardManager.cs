using Crm.Dtos.DashBoard;
using Crm.Dtos.Lead;
using Crm.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface IDashBoardManager
    {
        Task<AgentActiveInActiveDto> GetAgentActivity();
        Task<LeadActivityDto> GetLeadActivity();
        Task<AgentDashBoardDto> GetTodaysCallStatistics(int id);
        Task<CallStatisticsDto> GetAllCallStatistics();
    }
}
