using Crm.Dtos.LeadStatus;
using Crm.Models.LeadStatus;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface ILeadStatusManager
    {
        Task AddAsync(LeadStatusAddModel model);

        Task EditAsync(LeadStatusEditModel model);

        Task<LeadStatusDetailDto> GetDetailAsync(int id);

        Task<JqDataTableResponse<LeadStatusDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task DeleteAsync(int id);
        Task<List<LeadStatusDetailDto>> GetAllStatus();
    }
}
