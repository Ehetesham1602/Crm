using Crm.Entities;
using Crm.Models.Activities;
using Crm.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Factories
{
    public class ActivitiesFactory
    {
        //For Call
        public static ActivityCall CreateCall(ActivityCallModel model, string userId)
        {
            var call = new ActivityCall
            {
                CallSubject = model.CallSubject,
                CallDescription = model.CallDescription,
                CallPurpose = model.CallPurpose,
                CallDate = model.CallDate,
                CallTime = model.CallTime,
                UserId = model.UserId,
                DescriptionHtml = model.DescriptionHtml,
                EntityId = model.EntityId,
                EntityMasterId = model.EntityMasterId,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime()
            };
            return call;
        }

        public static void CreateCall(ActivityCallModel model, ActivityCall entity, string userId)
        {
            entity.CallSubject = model.CallSubject;
            entity.CallDescription = model.CallDescription;
            entity.CallPurpose = model.CallPurpose;
            entity.CallDate = model.CallDate;
            entity.CallTime = model.CallTime;
            entity.UserId = model.UserId;
            entity.DescriptionHtml = model.DescriptionHtml;
            entity.EntityId = model.EntityId;
            entity.EntityMasterId = model.EntityMasterId;
        }

        //For Meetting
        public static ActivityMeeting CreateMeeting(ActivityMeetingModel model, string userId)
        {
            var call = new ActivityMeeting
            {
                MeetingSubject = model.MeetingSubject,
                MeetingDescription = model.MeetingDescription,
                MeetingDate = model.MeetingDate,
                MeetingTime = model.MeetingTime,
                UserId = model.UserId,
                DescriptionHtml = model.DescriptionHtml,
                EntityId = model.EntityId,
                EntityMasterId = model.EntityMasterId,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime()
            };
            return call;
        }

        public static void CreateMeeting(ActivityMeetingModel model, ActivityMeeting entity, string userId)
        {
            entity.MeetingSubject = model.MeetingSubject;
            entity.MeetingDescription = model.MeetingDescription;
            entity.MeetingDate = model.MeetingDate;
            entity.MeetingTime = model.MeetingTime;
            entity.UserId = model.UserId;
            entity.DescriptionHtml = model.DescriptionHtml;
            entity.EntityId = model.EntityId;
            entity.EntityMasterId = model.EntityMasterId;
        }

        //For Notes
        public static ActivityNotes CreateNotes(ActivityNoteModel model, string userId)
        {
            var call = new ActivityNotes
            {
                NoteDescription = model.NoteDescription,
                DescriptionHtml = model.DescriptionHtml,
                EntityId = model.EntityId,
                EntityMasterId = model.EntityMasterId,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime()
            };
            return call;
        }

        public static void CreateNotes(ActivityNoteModel model, ActivityNotes entity, string userId)
        {
            entity.NoteDescription = model.NoteDescription;
            entity.DescriptionHtml = model.DescriptionHtml;
            entity.EntityId = model.EntityId;
            entity.EntityMasterId = model.EntityMasterId;
        }
    }
}
