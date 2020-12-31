using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Api.Helpers;
using Crm.Dtos.User;
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
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardManager _manager;
        private readonly IHostingEnvironment _environment;

        public DashBoardController(IDashBoardManager manager,
            IHostingEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }
        [HttpGet]
        [Route("get-Manager-Agent-Activity")]
        public async Task<IActionResult> GetAgentActivity()
        {
            return Ok(await _manager.GetAgentActivity());
        }
        [HttpGet]
        [Route("get-Manager-Lead-Statistics")]
        public async Task<IActionResult> GetLeadActivity()
        {
            return Ok(await _manager.GetLeadActivity());
        }
        [HttpGet]
        [Route("get-Todays-Call-Statistics/{id}")]
        public async Task<IActionResult> GetTodaysCallStatistics(int id)
        {
            return Ok(await _manager.GetTodaysCallStatistics(id));
        }
        [HttpGet]
        [Route("get-All-Call-Statistics")]
        public async Task<IActionResult> GetAllCallStatistics()
        {
            return Ok(await _manager.GetAllCallStatistics());
        }
    }
}
