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
    public class RegionStatesController : AdminApiController
    {
        private readonly IRegionStateService regionServices;
        private readonly ILogger<RegionStatesController> _logger;

        public RegionStatesController(IRegionStateService regionServices, ILogger<RegionStatesController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> Get(Guid countryId)
        {
            var result = await regionServices.GetList(countryId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertRegionState model)
        {
            var result = await regionServices.Add(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateRegionState model)
        {
            var result = await regionServices.Update(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRegionState model)
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
