using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Api.Helpers;
using Crm.Infrastructure.Managers;
using Crm.Models.Lead;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Crm.Utilities;

namespace Crm.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        //[Authorize]
            private readonly ILeadManager _leadManager;

            public LeadController(ILeadManager manager)
            {
            _leadManager = manager;
            }

            [HttpPost]
            [Route("add")]
            public async Task<IActionResult> Add([FromBody] LeadModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorList());
                }
                try
                {
                    await _leadManager.AddAsync(model);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok();
            }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] LeadModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _leadManager.EditAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _leadManager.DeleteAsync(id);
            return Ok();
        }

        [HttpPost]
        [Route("paged-result")]
        public async Task<IActionResult> GetPagedResult(JqDataTableRequest model)
        {
            var pagedResult = await _leadManager.GetPagedResultAsync(model);
            return Ok(pagedResult);
        }

        [HttpGet]
        [Route("get-detail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var lead = await _leadManager.GetDetailAsync(id);
            if (lead == null)
            {
                return NotFound();
            }
            return Ok(lead);

        }
        [HttpGet]
        [Route("get-AllLead")]
        public async Task<IActionResult> GetAllLead()
        {
            return Ok(await _leadManager.GetAllLead());
        }
    }
}
