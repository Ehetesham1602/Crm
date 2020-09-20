using Crm.Dtos.Lead;
using Crm.Entities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface ILeadRepository
    {
        Task AddAsync(Lead entity);
        void Edit(Lead entity);
        Task<Lead> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<JqDataTableResponse<LeadDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task<LeadDto> GetDetailAsync(int id);
        Task<List<LeadDto>> GetAllLead();
    }
}
