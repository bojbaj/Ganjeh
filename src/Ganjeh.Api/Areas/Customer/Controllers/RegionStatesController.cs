using System;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Customer.Base;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Customer.Controllers
{
    public class RegionStatesController : CustomerApiController
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
    }
}
