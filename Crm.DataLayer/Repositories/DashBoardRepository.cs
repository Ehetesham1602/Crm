
using Crm.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Crm.Utilities;
using Crm.Infrastructure.Repositories;
using Crm.Dtos.Lead;
using Crm.Dtos.UserLogin;

namespace Crm.DataLayer.Repositories
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly DataContext _dataContext;

        public DashBoardRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<UserDetailDto>> GetAgentActive()
        {
            var linq = await (from l in _dataContext.User
                              where l.Status == Constants.RecordStatus.Active
                              select new UserDetailDto
                              {
                                  Id = l.Id,
                                  FirstName = l.FirstName,
                                  LastName = l.LastName,
                                  Email = l.Email,
                                  Mobile = l.Mobile,
                                  Status = l.Status
                              })
                            .AsNoTracking()
                            .ToListAsync();
            return linq;
        }
        public async Task<List<UserDetailDto>> GetAgentInActive()
        {
            var linq = await (from l in _dataContext.User
                              where l.Status == Constants.RecordStatus.Inactive
                              select new UserDetailDto
                              {
                                  Id = l.Id,
                                  FirstName = l.FirstName,
                                  LastName = l.LastName,
                                  Email = l.Email,
                                  Mobile = l.Mobile,
                                  Status = l.Status
                              })
                            .AsNoTracking()
                            .ToListAsync();
            return linq;
        }
        public async Task<List<LeadDto>> GetLead()
        {
            var linq = await (from l in _dataContext.Lead
                              select new LeadDto
                              {
                                  Id = l.Id,
                                  FirstName = l.FirstName,
                                  LastName = l.LastName,
                                  Email = l.Email,
                                  Website = l.Website,
                                  Mobile = l.Mobile,
                                  LeadSourceId = l.LeadSourceId ?? 0,
                                  LeadStatusId = l.LeadStatusId ?? 0,
                                  Status = l.Status,
                                  Phone = l.Phone,
                              }
                             ).AsNoTracking().ToListAsync();

            return linq;
        }
        public async Task<List<LeadDto>> GetAllMonth(int mnt)
        {
            var dateTime = new DateTime(2000, mnt, 1);
            var linq = await (from l in _dataContext.Lead
                              where l.CreatedOn.Month == dateTime.Month
                              select new LeadDto
                              {
                                  Id = l.Id,
                                  FirstName = l.FirstName,
                                  LastName = l.LastName,
                                  Email = l.Email,
                                  Website = l.Website,
                                  Mobile = l.Mobile,
                                  LeadSourceId = l.LeadSourceId ?? 0,
                                  LeadStatusId = l.LeadStatusId ?? 0,
                                  Status = l.Status,
                                  Phone = l.Phone,
                              }).AsNoTracking().ToListAsync();
            return linq;
        }
        public async Task<List<LeadDto>> GetCallDone(int id)
        {
            /*DateTime startDateTime = DateTime.Today; //Today at 00:00:00
            DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59
            where (l.CreatedOn >= startDateTime && l.CreatedOn <= endDateTime) && l.CallStatus == false */
            var linq = await (from l in _dataContext.Lead
                              where l.UserId == id && l.CreatedOn.Date == DateTime.Today && l.CallStatus == Constants.LeadCallStatus.CallDone
                              select new LeadDto
                              {
                                  CreatedOn = l.CreatedOn
                              }
                              ).AsNoTracking().ToListAsync();
            return linq;
        }
        public async Task<List<LeadDto>> GetCallRemaining(int id)
        {
            var linq = await (from l in _dataContext.Lead
                              where l.UserId == id && l.CreatedOn.Date == DateTime.Today && l.CallStatus == Constants.LeadCallStatus.NotDone
                              select new LeadDto
                              {
                                  CreatedOn = l.CreatedOn
                              }).AsNoTracking().ToListAsync();
            return linq;
        }
        public async Task<List<LeadDto>> GetAllCallMonth(int mnt)
        {
            var dateTime = new DateTime(2000, mnt, 1);
            var linq = await (from l in _dataContext.Lead
                              where l.CallStatus == Constants.LeadCallStatus.CallDone && l.CreatedOn.Month == dateTime.Month
                              select new LeadDto
                              {
                                  Id = l.Id,
                                  FirstName = l.FirstName,
                                  LastName = l.LastName,
                                  Email = l.Email,
                                  Website = l.Website,
                                  Mobile = l.Mobile,
                                  LeadSourceId = l.LeadSourceId ?? 0,
                                  LeadStatusId = l.LeadStatusId ?? 0,
                                  Status = l.Status,
                                  Phone = l.Phone,
                              }).AsNoTracking().ToListAsync();
            return linq;
        }
    }
}
