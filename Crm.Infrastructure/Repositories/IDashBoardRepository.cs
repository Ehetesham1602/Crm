using Crm.Dtos.Lead;
using Crm.Dtos.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface IDashBoardRepository
    {
        Task<List<UserDetailDto>> GetAgentActive();
        Task<List<UserDetailDto>> GetAgentInActive();
        Task<List<LeadDto>> GetLead();
        Task<List<LeadDto>> GetAllMonth(int mnt);
        Task<List<LeadDto>> GetCallDone(int id);
        Task<List<LeadDto>> GetCallRemaining(int id);
        Task<List<LeadDto>> GetAllCallMonth(int i);
    }
}
