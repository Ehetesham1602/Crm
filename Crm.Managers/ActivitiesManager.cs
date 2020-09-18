using Crm.Dtos.Activities;
using Crm.Factories;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Models.Activities;
using Crm.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Managers
{
    public class ActivitiesManager : IActivitiesManager
    {
        private readonly IActivitiesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public ActivitiesManager(IHttpContextAccessor contextAccessor,
            IActivitiesRepository repository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        //For Call
        public async Task AddAsyncCall(ActivityCallModel model)
        {
            await _repository.AddCallAsync(ActivitiesFactory.CreateCall(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditAsync(ActivityCallModel model)
        {
            var call = await _repository.GetAsyncCall(model.Id);
            ActivitiesFactory.CreateCall(model, call, _userId);
            _repository.EditCall(call);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ActivityCallDetailDto> GetDetailAsync(ActivityGetModel model)
        {
            return await _repository.GetActivityCallAsyncById(model);
        }

        public async Task<JqDataTableResponse<ActivityCallDetailDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsync(model);
        }

        //For Meeting
        public async Task AddAsyncMeeting(ActivityMeetingModel model)
        {
            await _repository.AddMeetingAsync(ActivitiesFactory.CreateMeeting(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditAsyncMeeting(ActivityMeetingModel model)
        {
            var meet = await _repository.GetAsyncMeeting(model.Id);
            ActivitiesFactory.CreateMeeting(model, meet, _userId);
            _repository.EditMeeting(meet);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ActivityMeetingDetailDto> GetDetailAsyncMeeting(ActivityGetModel model)
        {
            return await _repository.GetActivityMeetingAsyncById(model);
        }

        public async Task<JqDataTableResponse<ActivityMeetingDetailDto>> GetPagedResultAsyncMeeting(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsyncMeeting(model);
        }

        //For Notes
        public async Task AddAsyncNotes(ActivityNoteModel model)
        {
            await _repository.AddNoteAsync(ActivitiesFactory.CreateNotes(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task EditAsyncNotes(ActivityNoteModel model)
        {
            var notes = await _repository.GetAsyncNotes(model.Id);
            ActivitiesFactory.CreateNotes(model, notes, _userId);
            _repository.EditNotes(notes);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ActivityNoteDto> GetDetailAsyncNotes(ActivityGetModel model)
        {
            return await _repository.GetActivityNoteAsyncById(model);
        }

        public async Task<JqDataTableResponse<ActivityNoteDto>> GetPagedResultAsyncNotes(JqDataTableRequest model)
        {
            return await _repository.GetPagedResultAsyncNotes(model);
        }
    }
}