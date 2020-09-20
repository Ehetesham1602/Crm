using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Infrastructure.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterManager _masterManager;
        public MasterController(IMasterManager masterManager)
        {
            _masterManager = masterManager;
        }

        [HttpGet]
        [Route("get-country")]
        public async Task<IActionResult> GetCountry()
        {
            var countries = await _masterManager.GetCountrySelectItemsAsync();
            if (countries == null)
            {
                BadRequest("unable to fatch countries");
            }
            return Ok(countries);
        }

        [HttpGet]
        [Route("get-detailState/{id}")]
        public async Task<IActionResult> GetDetailState(int id)
        {
            var state = await _masterManager.GetDetailAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);

        }
        [HttpGet]
        [Route("get-cityDetail/{id}")]
        public async Task<IActionResult> GetCityDetails(int id)
        {
            var city = await _masterManager.GetCityDetails(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);

        }
    }
}
