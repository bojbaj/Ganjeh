using System;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Admin.Base;
using Ganjeh.Api.Areas.Admin.Models.Regions;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class RegionStateController : AdminApiController
    {
        private readonly IRegionServices regionServices;
        private readonly ILogger<RegionStateController> _logger;

        public RegionStateController(IRegionServices regionServices, ILogger<RegionStateController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid CountryId)
        {
            var result = await regionServices.GetStates(CountryId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegionStateInsert model)
        {
            RegionState regionState = new RegionState()
            {
                Title = model.Title,
                RegionCountryId = model.CountryId
            };
            var result = await regionServices.AddState(regionState);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RegionStateUpdate model)
        {
            RegionState regionState = new RegionState()
            {
                Id = model.Id,
                Title = model.Title,
                RegionCountryId = model.CountryId
            };
            var result = await regionServices.UpdateState(regionState);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RegionStateDelete model)
        {
            var result = await regionServices.RemoveState(model.Id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
