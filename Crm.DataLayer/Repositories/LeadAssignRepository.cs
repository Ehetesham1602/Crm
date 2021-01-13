using Crm.Dtos.UserLogin;
using Crm.Entities;
using Crm.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Crm.Utilities;
using Microsoft.EntityFrameworkCore;
using Crm.Dtos.Lead;
using Crm.Models.Lead;

namespace Crm.DataLayer.Repositories
{
    public class LeadAssignRepository : ILeadAssignRepository
    {
        private readonly DataContext _dataContext;
        public LeadAssignRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public void Edit(Lead entity)
        {
            _dataContext.Update(entity);
        }
        public async Task<List<UserDetailDto>> GetAllUser()
        {
            var linqstmt = await (from u in _dataContext.User
                                  where u.Status != Constants.RecordStatus.Deleted && u.Role.RoleName == "Agent"
                                  select new UserDetailDto
                                  {
                                      Id = u.Id,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      UserName = u.UserName,
                                      Password = u.Password,
                                      Mobile = u.Mobile,
                                      Email = u.Email,
                                      RoleId = u.RoleId,
                                      RoleName = u.Role.RoleName

                                  })
                            .AsNoTracking()
                            .ToListAsync();

            return linqstmt;
        }
        public async Task<List<LeadDto>> GetAllLead()
        {
            var linqstmt = await (from l in _dataContext.Lead
                                  where l.Status != Constants.RecordStatus.Deleted && l.CallStatus == Constants.LeadCallStatus.NotDone && l.UserId == null
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
                                      UserId = l.UserId ?? 0,
                                      CallStatus = l.CallStatus

                                  })
                            .AsNoTracking()
                            .ToListAsync();

            return linqstmt;
        }
        public async Task<List<LeadDto>> GetByAgentIdAsync(int id)
        {
            return await (from l in _dataContext.Lead
                          where l.UserId == id && l.Status != Constants.RecordStatus.Deleted
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
                              UserId = l.UserId,
                              CallStatus = l.CallStatus
                          })
                          .AsNoTracking()
                         .ToListAsync();
        }

        /*public async Task<LeadDto> ChechCallStatusByIdAsync(int id)
        {
            var linq = await (from l in _dataContext.Lead
                        where l.Id == id && l.CallStatus == false
                        select new LeadDto
                        {
                            Id = l.Id,
                            UserId = l.UserId,
                            CallStatus = l.CallStatus
                        }).AsNoTracking().SingleOrDefaultAsync();
            
            return linq;
        }*/
        public async Task ChangeCallStatusByIdAsync(ChangeCallStatusModel changeCallStatusModel )
        {
            var lead = await _dataContext.Lead.FindAsync(changeCallStatusModel.Id);
            lead.CallStatus = changeCallStatusModel.CallStatus;
            _dataContext.Lead.Update(lead);
        }
    }
}
