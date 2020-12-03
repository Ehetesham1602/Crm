using Crm.Dtos.Activities;
using Crm.Entities;
using Crm.Models.Activities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface IActivitiesRepository
    {
        Task AddCallAsync(ActivityCall entity);
        void EditCall(ActivityCall entity);
        Task<ActivityCall> GetAsyncCall(int id);
        Task<JqDataTableResponse<ActivityCallDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task<List<ActivityCallDetailDto>> GetActivityCallAsyncById(ActivityGetModel model);


        Task AddMeetingAsync(ActivityMeeting entity);
        void EditMeeting(ActivityMeeting entity);
        Task<ActivityMeeting> GetAsyncMeeting(int id);
        Task<JqDataTableResponse<ActivityMeetingDetailDto>> GetPagedResultAsyncMeeting(JqDataTableRequest model);
        Task<List<ActivityMeetingDetailDto>> GetActivityMeetingAsyncById(ActivityGetModel model);

        Task AddNoteAsync(ActivityNotes entity);
        void EditNotes(ActivityNotes entity);
        Task<ActivityNotes> GetAsyncNotes(int id);
        Task<JqDataTableResponse<ActivityNoteDto>> GetPagedResultAsyncNotes(JqDataTableRequest model);
        Task<List<ActivityNoteDto>> GetActivityNoteAsyncById(ActivityGetModel model);

    }
}
