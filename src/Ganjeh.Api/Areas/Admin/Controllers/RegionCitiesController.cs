using System;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Admin.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Models.Regions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class RegionCitiesController : AdminApiController
    {
        private readonly IRegionCityService regionServices;
        private readonly ILogger<RegionCitiesController> _logger;

        public RegionCitiesController(IRegionCityService regionServices, ILogger<RegionCitiesController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet("{stateId}")]
        public async Task<IActionResult> Get(Guid stateId)
        {
            var result = await regionServices.GetList(stateId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertRegionCity model)
        {
            var result = await regionServices.Add(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateRegionCity model)
        {
            var result = await regionServices.Update(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRegionCity model)
        {
            var result = await regionServices.Remove(model.Id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
