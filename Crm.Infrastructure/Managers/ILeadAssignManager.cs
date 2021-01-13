using Crm.Dtos.Lead;
using Crm.Entities;
using Crm.Models.Lead;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface ILeadAssignManager
    {
        Task EditAsync(List<LeadDto> leadList);
        Task<List<LeadDto>> GetByAgentIdAsync(int id);
        //Task UpdateCallStatusAsync(int id);
        Task ChangeCallStatusByIdAsync(ChangeCallStatusModel changeCallStatusModel);
    }
}
