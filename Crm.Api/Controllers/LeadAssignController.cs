using Crm.Api.Helpers;
using Crm.Dtos.Lead;
using Crm.Dtos.LeadAssign;
using Crm.Dtos.UserLogin;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Crm.Models.Lead;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LeadAssignController : ControllerBase
    {
        //[Authorize]
        private readonly ILeadAssignManager _leadAssignManager;
        private readonly ILeadManager _leadManager;
        private readonly ILeadAssignRepository _leadAssignRepository;
        private readonly IUnitOfWork _unitOfWork;
        public LeadAssignController(ILeadAssignManager manager, ILeadManager leadmanager, ILeadAssignRepository repository, IUnitOfWork unitOfWork)
        {
            _leadAssignManager = manager;
            _leadManager = leadmanager;
            _leadAssignRepository = repository;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _leadAssignManager.EditAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet]
        [Route("get-lead-assign-info")]
        public async Task<List<LeadAssignDto>> GetLeadAssignInfoAsync()
        {
            return await _leadAssignManager.GetLeadAssignInfoAsync();

        }
        [HttpGet]
        [Route("get-agent-by/{id}")]
        public async Task<IActionResult> GetAgentById(int id)
        {
            var lead = await _leadAssignManager.GetByAgentIdAsync(id);
            if (lead == null)
            {
                return NotFound();
            }
            return Ok(lead);

        }
        [HttpPost]
        [Route("change-call-status-by")]
        public async Task<IActionResult> ChangeCallStatusById(ChangeCallStatusModel changeCallStatusModel)
        {
            await _leadAssignManager.ChangeCallStatusByIdAsync(changeCallStatusModel);
            return Ok();
            /*var leadId = await _leadAssignRepository.ChechCallStatusByIdAsync(id);
            
            if (leadId != null)
            {
                await _leadAssignManager.UpdateCallStatusAsync(leadId);
            }
            return Ok();*/

        }
    }
}
