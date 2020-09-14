using Crm.Dtos.LeadSource;
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
    public class LeadSourceRepository: ILeadSourceRepository
    {
        private readonly DataContext _dataContext;

        public LeadSourceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(LeadSource entity)
        {
            await _dataContext.LeadSource.AddAsync(entity);
        }

        public void Edit(LeadSource entity)
        {
            _dataContext.LeadSource.Update(entity);
        }

        public async Task<LeadSource> GetAsync(int id)
        {
            return await _dataContext.LeadSource.FindAsync(id);
        }

        public async Task<LeadSourceDetailDto> GetDetailAsync(int id)
        {
            return await (from s in _dataContext.LeadSource
                          where s.Id == id
                          select new LeadSourceDetailDto
                          {
                              Id = s.Id,
                              Name = s.Name
                          })
                          .AsNoTracking()
                          .SingleOrDefaultAsync();
        }

        public async Task<JqDataTableResponse<LeadSourceDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }

            var filterKey = model.Search.Value;

            var linqStmt = (from s in _dataContext.LeadSource
                            where s.Status != Constants.RecordStatus.Deleted && (filterKey == null || EF.Functions.Like(s.Name, "%" + filterKey + "%"))
                            select new LeadSourceDetailDto
                            {
                                Id = s.Id,
                                Name = s.Name
                            })
                            .AsNoTracking();

            var sortExpresstion = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<LeadSourceDetailDto>
            {
                RecordsTotal = await _dataContext.LeadSource.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqStmt.CountAsync(),
                Data = await linqStmt.OrderBy(sortExpresstion).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

    }
}
