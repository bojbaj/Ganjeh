using System;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Customer.Base;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Customer.Controllers
{
    public class RegionStateController : CustomerApiController
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
    }
}
