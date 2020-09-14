using Crm.Dtos.LeadSource;
using Crm.Entities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface ILeadSourceRepository
    {
        Task AddAsync(LeadSource entity);

        void Edit(LeadSource entity);

        Task<LeadSource> GetAsync(int id);

        Task<LeadSourceDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<LeadSourceDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
    }
}
