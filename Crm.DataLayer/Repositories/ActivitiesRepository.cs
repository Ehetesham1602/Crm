using Crm.Dtos.Activities;
using Crm.Entities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Crm.Models.Activities;
using Crm.Infrastructure.Repositories;

namespace Crm.DataLayer.Repositories
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly DataContext _dataContext;
        public ActivitiesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //For ActivityCall
        public async Task AddCallAsync(ActivityCall entity)
        {
            await _dataContext.ActivityCall.AddAsync(entity);
        }

        public void EditCall(ActivityCall entity)
        {
            _dataContext.ActivityCall.Update(entity);
        }

        public async Task<ActivityCall> GetAsyncCall(int id)
        {
            return await _dataContext.ActivityCall.FindAsync(id);
        }

        public async Task<JqDataTableResponse<ActivityCallDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }
            var filerKey = model.Search.Value;

            var linqstmt = (from ac in _dataContext.ActivityCall
                            where (filerKey == null || EF.Functions.Like(ac.CallSubject, "%" + filerKey + "%")
                            || EF.Functions.Like(ac.CallDescription, "%" + filerKey + "%"))
                            select new ActivityCallDetailDto
                            {
                                Id = ac.Id,
                                CallSubject = ac.CallSubject,
                                CallDescription = ac.CallDescription,
                                CallPurpose = ac.CallPurpose,
                                CallDate = ac.CallDate,
                                CallTime = ac.CallTime,
                                UserId = ac.UserId,
                                DescriptionHtml = ac.DescriptionHtml,
                                EntityId = ac.EntityId,
                                EntityMasterId = ac.EntityMasterId
                            })
                           .AsNoTracking();

            var sortExpression = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<ActivityCallDetailDto>
            {
                RecordsTotal = await _dataContext.ActivityCall.CountAsync(),
                RecordsFiltered = await linqstmt.CountAsync(),
                Data = await linqstmt.OrderBy(sortExpression).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task<List<ActivityCallDetailDto>> GetActivityCallAsyncById(ActivityGetModel model)
        {
            return await (from ac in _dataContext.ActivityCall
                          where ac.EntityId == model.EntityId && ac.EntityMasterId == model.EntityMasterId
                          select new ActivityCallDetailDto
                          {
                              Id = ac.Id,
                              CallSubject = ac.CallSubject,
                              CallDescription = ac.CallDescription,
                              CallPurpose = ac.CallPurpose,
                              CallDate = ac.CallDate,
                              CallTime = ac.CallTime,
                              UserId = ac.UserId,
                              DescriptionHtml = ac.DescriptionHtml,
                              EntityId = ac.EntityId,
                              EntityMasterId = ac.EntityMasterId
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }

        //For Activity Meeting
        public async Task AddMeetingAsync(ActivityMeeting entity)
        {
            await _dataContext.ActivityMeeting.AddAsync(entity);
        }

        public void EditMeeting(ActivityMeeting entity)
        {
            _dataContext.ActivityMeeting.Update(entity);
        }

        public async Task<ActivityMeeting> GetAsyncMeeting(int id)
        {
            return await _dataContext.ActivityMeeting.FindAsync(id);
        }

        public async Task<JqDataTableResponse<ActivityMeetingDetailDto>> GetPagedResultAsyncMeeting(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }
            var filerKey = model.Search.Value;

            var linqstmt = (from am in _dataContext.ActivityMeeting
                            where (filerKey == null || EF.Functions.Like(am.MeetingDescription, "%" + filerKey + "%")
                            || EF.Functions.Like(am.MeetingSubject, "%" + filerKey + "%"))
                            select new ActivityMeetingDetailDto
                            {
                                Id = am.Id,
                                MeetingSubject = am.MeetingSubject,
                                MeetingDescription = am.MeetingDescription,
                                MeetingDate = am.MeetingDate,
                                MeetingTime = am.MeetingTime,
                                UserId = am.UserId,
                                DescriptionHtml = am.DescriptionHtml,
                                EntityId = am.EntityId,
                                EntityMasterId = am.EntityMasterId
                            })
                           .AsNoTracking();

            var sortExpression = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<ActivityMeetingDetailDto>
            {
                RecordsTotal = await _dataContext.ActivityMeeting.CountAsync(),
                RecordsFiltered = await linqstmt.CountAsync(),
                Data = await linqstmt.OrderBy(sortExpression).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task<List<ActivityMeetingDetailDto>> GetActivityMeetingAsyncById(ActivityGetModel model)
        {
            return await (from am in _dataContext.ActivityMeeting
                          where am.EntityId == model.EntityId && am.EntityMasterId == model.EntityMasterId
                          select new ActivityMeetingDetailDto
                          {
                              Id = am.Id,
                              MeetingSubject = am.MeetingSubject,
                              MeetingDescription = am.MeetingDescription,
                              MeetingDate = am.MeetingDate,
                              MeetingTime = am.MeetingTime,
                              UserId = am.UserId,
                              DescriptionHtml = am.DescriptionHtml,
                              EntityId = am.EntityId,
                              EntityMasterId = am.EntityMasterId
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }


        //For Activity Note
        public async Task AddNoteAsync(ActivityNotes entity)
        {
            await _dataContext.ActivityNotes.AddAsync(entity);
        }

        public void EditNotes(ActivityNotes entity)
        {
            _dataContext.ActivityNotes.Update(entity);
        }

        public async Task<ActivityNotes> GetAsyncNotes(int id)
        {
            return await _dataContext.ActivityNotes.FindAsync(id);
        }

        public async Task<JqDataTableResponse<ActivityNoteDto>> GetPagedResultAsyncNotes(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }
            var filerKey = model.Search.Value;

            var linqstmt = (from an in _dataContext.ActivityNotes
                            where (filerKey == null || EF.Functions.Like(an.NoteDescription, "%" + filerKey + "%"))
                            select new ActivityNoteDto
                            {
                                Id = an.Id,
                                NoteDescription = an.NoteDescription,
                                DescriptionHtml = an.DescriptionHtml,
                                EntityId = an.EntityId,
                                EntityMasterId = an.EntityMasterId
                            })
                           .AsNoTracking();

            var sortExpression = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<ActivityNoteDto>
            {
                RecordsTotal = await _dataContext.ActivityMeeting.CountAsync(),
                RecordsFiltered = await linqstmt.CountAsync(),
                Data = await linqstmt.OrderBy(sortExpression).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }

        public async Task<List<ActivityNoteDto>> GetActivityNoteAsyncById(ActivityGetModel model)
        {
            return await (from an in _dataContext.ActivityNotes
                          where an.EntityId == model.EntityId && an.EntityMasterId == model.EntityMasterId
                          select new ActivityNoteDto
                          {
                              Id = an.Id,
                              NoteDescription = an.NoteDescription,
                              DescriptionHtml = an.DescriptionHtml,
                              EntityId = an.EntityId,
                              EntityMasterId = an.EntityMasterId
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task AddTaskAsync(ActivityTask entity)
        {
            await _dataContext.ActivityTask.AddAsync(entity);
        }
        public void EditAsyncTask(ActivityTask entity)
        {
            _dataContext.ActivityTask.Update(entity);
        }
        public async Task<ActivityTask> GetAsyncTask(int id)
        {
            return await _dataContext.ActivityTask.FindAsync(id);
        }
        public async Task<List<ActivityTaskDetailDto>> GetActivityTaskAsyncById(ActivityGetModel model)
        {
            return await (from ac in _dataContext.ActivityTask
                          where ac.EntityId == model.EntityId && ac.EntityMasterId == model.EntityMasterId
                          select new ActivityTaskDetailDto
                          {
                              Id = ac.Id,
                              TaskSubject = ac.TaskSubject,
                              TaskDescription = ac.TaskDescription,
                              TaskPurpose = ac.TaskPurpose,
                              TaskDate = ac.TaskDate,
                              TaskTime = ac.TaskTime,
                              UserId = ac.UserId,
                              DescriptionHtml = ac.DescriptionHtml,
                              EntityId = ac.EntityId,
                              EntityMasterId = ac.EntityMasterId
                          })
                          .AsNoTracking()
                          .ToListAsync();
        }
        public async Task<JqDataTableResponse<ActivityTaskDetailDto>> GetPagedResultAsyncTask(JqDataTableRequest model)
        {
            if (model.Length == 0)
            {
                model.Length = Constants.DefaultPageSize;
            }
            var filerKey = model.Search.Value;

            var linqstmt = (from ac in _dataContext.ActivityTask
                            where (filerKey == null || EF.Functions.Like(ac.TaskSubject, "%" + filerKey + "%")
                            || EF.Functions.Like(ac.TaskDescription, "%" + filerKey + "%"))
                            select new ActivityTaskDetailDto
                            {
                                Id = ac.Id,
                                TaskSubject = ac.TaskSubject,
                                TaskDescription = ac.TaskDescription,
                                TaskPurpose = ac.TaskPurpose,
                                TaskDate = ac.TaskDate,
                                TaskTime = ac.TaskTime,
                                UserId = ac.UserId,
                                DescriptionHtml = ac.DescriptionHtml,
                                EntityId = ac.EntityId,
                                EntityMasterId = ac.EntityMasterId
                            })
                           .AsNoTracking();

            var sortExpression = model.GetSortExpression();

            var pagedResult = new JqDataTableResponse<ActivityTaskDetailDto>
            {
                RecordsTotal = await _dataContext.ActivityTask.CountAsync(),
                RecordsFiltered = await linqstmt.CountAsync(),
                Data = await linqstmt.OrderBy(sortExpression).Skip(model.Start).Take(model.Length).ToListAsync()
            };
            return pagedResult;
        }
    }
}

