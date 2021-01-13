using System;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Customer.Base;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Customer.Controllers
{
    public class RegionCitiesController : CustomerApiController
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
    }
}
