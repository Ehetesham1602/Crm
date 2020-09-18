using Crm.Dtos.LeadStatus;
using Crm.Entities;
using Crm.Infrastructure.Repositories;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace Crm.DataLayer.Repositories
{
    public class LeadStatusRepository : ILeadStatusRepository
    {
        private readonly DataContext _dataContext;

        public LeadStatusRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(LeadStatus entity)
        {
            await _dataContext.LeadStatus.AddAsync(entity);
        }

        public void Edit(LeadStatus entity)
        {
            _dataContext.LeadStatus.Update(entity);
        }

        public async Task<LeadStatus> GetAsync(int id)
        {
            return await _dataContext.LeadStatus.FindAsync(id);
        }

        public async Task<LeadStatusDetailDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.LeadStatus
                          where s.Id == id
                          select new LeadStatusDetailDto
                          {
                              Id = s.Id,
                              Name = s.Name
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task<JqDataTableResponse<LeadStatusDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.LeadStatus
                            where s.Status != Constants.RecordStatus.Deleted && (filterKey == null || EF.Functions.Like(s.Name, "%" + filterKey + "%"))
                            select new LeadStatusDetailDto
                            {
                                Id = s.Id,
                                Name = s.Name
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<LeadStatusDetailDto>
            {
                RecordsTotal = await _dataContext.LeadSource.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dataContext.LeadStatus.FindAsync(id);
            data.Status = Constants.RecordStatus.Deleted;
            _dataContext.LeadStatus.Update(data);
        }

    }
}
