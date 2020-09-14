using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Api.Helpers;
using Crm.Infrastructure.Managers;
using Crm.Models.LeadStatus;
using Crm.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LeadStatusController : ControllerBase
    { 
    private readonly ILeadStatusManager _manager;
    private readonly IHostingEnvironment _environment;

    public LeadStatusController(ILeadStatusManager manager,
        IHostingEnvironment environment)
    {
        _manager = manager;
        _environment = environment;
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] LeadStatusAddModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorList());
        }

        try
        {
            await _manager.AddAsync(model);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPost]
    [Route("edit")]
    public async Task<IActionResult> Edit([FromBody] LeadStatusEditModel model)
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

    [HttpGet]
    [AllowAnonymous]
    [Route("get-detail/{id}")]
    public async Task<IActionResult> GetDetail(int id)
    {
        var leadData = await _manager.GetDetailAsync(id);
        if (leadData == null)
        {
            return NotFound();
        }
        return Ok(leadData);
    }

    [HttpPost]
    [Route("paged-result")]
    public async Task<IActionResult> PagedResult(JqDataTableRequest model)
    {
        return Ok(await _manager.GetPagedResultAsync(model));
    }
        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.DeleteAsync(id);

            return Ok();
        }
    }
}

