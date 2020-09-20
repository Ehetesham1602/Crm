using Crm.Dtos.LeadStatus;
using Crm.Entities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface ILeadStatusRepository
    {
        Task AddAsync(LeadStatus entity);

        void Edit(LeadStatus entity);

        Task<LeadStatus> GetAsync(int id);

        Task<LeadStatusDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<LeadStatusDetailDto>> GetPagedResultAsync(JqDataTableRequest model);

        Task DeleteAsync(int id);
        Task<List<LeadStatusDetailDto>> GetAllStatus();
    }
}
