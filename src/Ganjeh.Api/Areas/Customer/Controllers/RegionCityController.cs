using System;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Customer.Base;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Customer.Controllers
{
    public class RegionCityController : CustomerApiController
    {
        private readonly IRegionServices regionServices;
        private readonly ILogger<RegionCityController> _logger;

        public RegionCityController(IRegionServices regionServices, ILogger<RegionCityController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid StateId)
        {
            var result = await regionServices.GetCities(StateId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
