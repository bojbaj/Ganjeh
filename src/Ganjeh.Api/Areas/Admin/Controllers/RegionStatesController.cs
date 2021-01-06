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
    public class RegionStatesController : AdminApiController
    {
        private readonly IRegionServices regionServices;
        private readonly ILogger<RegionStatesController> _logger;

        public RegionStatesController(IRegionServices regionServices, ILogger<RegionStatesController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> Get(Guid countryId)
        {
            var result = await regionServices.GetStates(countryId);
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
