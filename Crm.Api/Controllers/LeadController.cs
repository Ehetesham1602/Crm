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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using System.IO;
using Crm.Models.Email;
using AccountErp.Infrastructure.Managers;

namespace Crm.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        //[Authorize]
            private readonly ILeadManager _leadManager;
            private readonly IHostingEnvironment _hostingEnvironment;
            private readonly IEmailManager _emailManager;
            public LeadController(ILeadManager manager, IHostingEnvironment hostingEnvironment, IEmailManager emailManager)
            {
            _leadManager = manager;
            _hostingEnvironment = hostingEnvironment;
            _emailManager = emailManager;
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

        [HttpPost]
        [Route("paged-result-byid")]
        public async Task<IActionResult> GetPagedResultById(JqDataTableRequest model)
        {
            var pagedResult = await _leadManager.GetPagedResultAsyncById(model);
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
        [HttpPost]
        [Route("add_lead")]
        public async Task<IActionResult> AddLead([FromBody] List<LeadModels> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            try
            {
                await _leadManager.AddLeadAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
      
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendLead(EmailLeadModel model)
        {
            var lead = await _leadManager.GetDetailAsync(model.Id);
            if (lead.Email == null)
            {
                BadRequest("Customer doesn't have email address");
            }

            var dirPath = Utility.GetEmailFolder(_hostingEnvironment.WebRootPath);
            var completePath = dirPath + model.FileName;
            if (!System.IO.File.Exists(completePath))
            {
                completePath = null;
                //var renderer = new IronPdf.HtmlToPdf();
                //renderer.RenderHtmlAsPdf(model.Html).SaveAs(completePath);
            }
            await _emailManager.SendLeadAsync(lead.Email,model, completePath);
           // await _emailManager.SendLeadAsync(lead.Email, model);
            return Ok();
        }

        [HttpPost]
        [Route("upload-attachment")]
        public async Task<IActionResult> UploadAttachment([FromForm] IFormFile file)
        {
            var dirPath = Utility.GetEmailFolder(_hostingEnvironment.WebRootPath);

            var fileName = Utility.GetUniqueFileName(file.FileName);

            using (var fileStream = new FileStream(dirPath + fileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok(new
            {
                fileName,
                fileUrl = Utility.GetEmailAttachmentFileUrl(Request.GetBaseUrl(), fileName)
            });
        }

        [HttpGet]
        [Route("get-AllCount")]
        public IActionResult GetAllCount()
        {
            return Ok( _leadManager.GetAllCount());
        }
    }
}
