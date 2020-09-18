using Crm.Dtos.Activities;
using Crm.Models.Activities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface IActivitiesManager
    {
        Task AddAsyncCall(ActivityCallModel model);
        Task EditAsync(ActivityCallModel model);
        Task<ActivityCallDetailDto> GetDetailAsync(ActivityGetModel model);
        Task<JqDataTableResponse<ActivityCallDetailDto>> GetPagedResultAsync(JqDataTableRequest model);
        Task AddAsyncMeeting(ActivityMeetingModel model);
        Task EditAsyncMeeting(ActivityMeetingModel model);
        Task<ActivityMeetingDetailDto> GetDetailAsyncMeeting(ActivityGetModel model);
        Task<JqDataTableResponse<ActivityMeetingDetailDto>> GetPagedResultAsyncMeeting(JqDataTableRequest model);
        Task AddAsyncNotes(ActivityNoteModel model);
        Task EditAsyncNotes(ActivityNoteModel model);
        Task<ActivityNoteDto> GetDetailAsyncNotes(ActivityGetModel model);
        Task<JqDataTableResponse<ActivityNoteDto>> GetPagedResultAsyncNotes(JqDataTableRequest model);
    }
}
