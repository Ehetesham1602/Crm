using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Api.Helpers;
using Crm.Infrastructure.Managers;
using Crm.Models.Activities;
using Crm.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesManager _manager;

        public ActivitiesController(IActivitiesManager manager)
        {
            _manager = manager;
        }

        //For Call
        [HttpPost]
        [Route("addCall")]
        public async Task<IActionResult> AddCall([FromBody] ActivityCallModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.AddAsyncCall(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("editCall")]
        public async Task<IActionResult> EditCall([FromBody] ActivityCallModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.EditAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("paged-result-call")]
        public async Task<IActionResult> GetPagedResultCall(JqDataTableRequest model)
        {
            var pagedResult = await _manager.GetPagedResultAsync(model);
            return Ok(pagedResult);
        }

        [HttpPost]
        [Route("get-call-detail")]
        public async Task<IActionResult> GetDetailCall(ActivityGetModel model)
        {
            var call = await _manager.GetDetailAsync(model);
            if (call == null)
            {
                return NotFound();
            }
            return Ok(call);

        }

        //For Meeting
        [HttpPost]
        [Route("addMeeting")]
        public async Task<IActionResult> AddMeeting([FromBody] ActivityMeetingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.AddAsyncMeeting(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("editMeeting")]
        public async Task<IActionResult> EditMeeting([FromBody] ActivityMeetingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.EditAsyncMeeting(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("paged-result-meeting")]
        public async Task<IActionResult> GetPagedResultMeeting(JqDataTableRequest model)
        {
            var pagedResult = await _manager.GetPagedResultAsyncMeeting(model);
            return Ok(pagedResult);
        }

        [HttpPost]
        [Route("get-Meeting-detail")]
        public async Task<IActionResult> GetDetailMeeting(ActivityGetModel model)
        {
            var meet = await _manager.GetDetailAsyncMeeting(model);
            if (meet == null)
            {
                return NotFound();
            }
            return Ok(meet);

        }

        //For Notes
        [HttpPost]
        [Route("addNotes")]
        public async Task<IActionResult> AddNotes([FromBody] ActivityNoteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.AddAsyncNotes(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("editNotes")]
        public async Task<IActionResult> EditNotes([FromBody] ActivityNoteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.EditAsyncNotes(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("paged-result-notes")]
        public async Task<IActionResult> GetPagedResultNotes(JqDataTableRequest model)
        {
            var pagedResult = await _manager.GetPagedResultAsyncNotes(model);
            return Ok(pagedResult);
        }

        [HttpPost]
        [Route("get-notes-detail")]
        public async Task<IActionResult> GetDetailNotes(ActivityGetModel model)
        {
            var note = await _manager.GetDetailAsyncNotes(model);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);

        }
        //For Task
        [HttpPost]
        [Route("addTask")]
        public async Task<IActionResult> AddTask([FromBody] ActivityTaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.AddAsyncTask(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost]
        [Route("editTask")]
        public async Task<IActionResult> EditTask([FromBody] ActivityTaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _manager.EditAsyncTask(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPost]
        [Route("get-Task-detail")]
        public async Task<IActionResult> GetDetailTask(ActivityGetModel model)
        {
            var call = await _manager.GetTaskDetailAsync(model);
            if (call == null)
            {
                return NotFound();
            }
            return Ok(call);

        }
        [HttpPost]
        [Route("paged-result-task")]
        public async Task<IActionResult> GetPagedResultTask(JqDataTableRequest model)
        {
            var pagedResult = await _manager.GetPagedResultAsyncTask(model);
            return Ok(pagedResult);
        }

    }
}

