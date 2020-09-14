using Crm.Dtos.LeadSource;
using Crm.Entities;
using Crm.Models.LeadSource;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
     public interface ILeadSourceManager
    {
        Task AddAsync(LeadSourceAddModel model);

        Task EditAsync(LeadSourceEditModel model);

        Task<LeadSourceDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<LeadSourceDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
    }
}
