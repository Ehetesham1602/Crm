using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Api.Helpers;
using Crm.Infrastructure.Managers;
using Crm.Models.UserLogin;
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
    public class UserController : ControllerBase
    {
        private readonly IUserManager _manager;
        private readonly IHostingEnvironment _environment;

        public UserController(IUserManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] UserRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            if(await _manager.CheckUser(model.UserName) != null)
            {
                return BadRequest("UserName Already Exist");
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
        public async Task<IActionResult> Edit([FromBody] UserRegistrationModel model)
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
            var data = await _manager.GetDetailAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
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
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorList());
            }
            var data = await _manager.CheckUser(model.UserName);
            if(data != null)
            {
                if (model.Password != Utility.Decrypt(data.Password))
                {
                    return BadRequest("Invalid Password");
                }
                else
                {
                   // HttpContext.Session.SetString("UserId", data.Id.ToString());
                    return Ok(data);
                }
            }
            else
            {
                return BadRequest("Invalid UserName");
            }
           
            
        }

    }
}