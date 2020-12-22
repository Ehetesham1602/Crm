using Crm.Api.Helpers;
using Crm.Dtos.Lead;
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
                //List<LeadDto> leadList = await _leadManager.GetAllLead();
                List<LeadDto> leadList = await _leadAssignRepository.GetAllLead();
                List<UserDetailDto> userList = await _leadAssignRepository.GetAllUser();
                var leadCount = leadList.Count();
                var userCount = userList.Count();
                var size = leadCount / userCount;
                if (leadCount % 2 != 0 && userCount > 1)
                {
                    size = size + 1;
                }
                int k = 0;
                for (int i = 0; i < userCount; i++)
                {
                    for (int j = i; j < size; j++)
                    {
                        leadList[k].UserId = userList[i].Id;
                        k++;

                    }

                }

                await _leadAssignManager.EditAsync(leadList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
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
    }
}
