using Crm.Dtos.Lead;
using Crm.Entities;
using Crm.Infrastructure.Repositories;
using Crm.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;


namespace Crm.DataLayer.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly DataContext _dataContext;
        public LeadRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Lead entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public void Edit(Lead entity)
        {
            _dataContext.Update(entity);
        }

        public async Task<Lead> GetAsync(int id)
        {
            return await _dataContext.Lead.FindAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
            var lead = await _dataContext.Lead.FindAsync(id);
            lead.Status = Constants.RecordStatus.Deleted;
            _dataContext.Lead.Update(lead);
        }
        public async Task<JqDataTableResponse<LeadDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }
            var filerKey = model.Search.Value;

            var linqstmt = (from l in _dataContext.Lead
                            where l.Status != Constants.RecordStatus.Deleted && (filerKey == null || EF.Functions.Like(l.FirstName, "%" + filerKey + "%")
                            || EF.Functions.Like(l.LastName, "%" + filerKey + "%"))
                            select new LeadDto
                            {
                                Id = l.Id,
                                FirstName = l.FirstName,
                                LastName = l.LastName,
                                Email = l.Email,
                                Website = l.Website,
                                Mobile = l.Mobile,
                                LeadSourceId = l.LeadSourceId,
                                LeadStatusId = l.LeadStatusId,
                                Status = l.Status
                            })
                           .AsNoTracking();

            var sortExpression = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<LeadDto>
            {
                RecordsTotal = await _dataContext.Lead.CountAsync(x => x.Status != Constants.RecordStatus.Deleted),
                RecordsFiltered = await linqstmt.CountAsync(),
                Data = await linqstmt.OrderBy(sortExpression).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }


    }
}
