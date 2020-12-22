using Crm.Dtos.Lead;
using Crm.Dtos.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface ILeadAssignRepository
    {
        Task<List<UserDetailDto>> GetAllUser();
        Task<List<LeadDto>> GetByAgentIdAsync(int id);
        Task<List<LeadDto>> GetAllLead();
        Task ChechCallStatusByIdAsync(int id);
        //Task<LeadDto> ChechCallStatusByIdAsync(int id);

        // void Edit(List<LeadDto> leadList);
    }
}
