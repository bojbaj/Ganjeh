using System.Threading.Tasks;
using Ganjeh.Api.Areas.Customer.Base;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Customer.Controllers
{
    public class RegionCountriesController : CustomerApiController
    {
        private readonly IRegionServices regionServices;
        private readonly ILogger<RegionCountriesController> _logger;

        public RegionCountriesController(IRegionServices regionServices, ILogger<RegionCountriesController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await regionServices.GetCountries();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
