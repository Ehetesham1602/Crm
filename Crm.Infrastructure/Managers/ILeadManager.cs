using Crm.Dtos.Lead;
using Crm.Models.Lead;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface ILeadManager
    {
        Task AddAsync(LeadModel model);
        Task EditAsync(LeadModel model);
        Task DeleteAsync(int id);
        Task<LeadDto> GetDetailAsync(int id);
        Task<JqDataTableResponse<LeadDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task<List<LeadDto>> GetAllLead();
        Task AddLeadAsync(List<LeadModels> model);
    }
}
