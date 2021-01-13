using System.Threading.Tasks;
using Ganjeh.Api.Areas.Admin.Base;
using Ganjeh.Api.Areas.Admin.Models.Regions;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class RegionCountriesController : AdminApiController
    {
        private readonly IRegionCountryServices regionServices;
        private readonly ILogger<RegionCountriesController> _logger;

        public RegionCountriesController(IRegionCountryServices regionServices, ILogger<RegionCountriesController> logger)
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegionCountryInsert model)
        {
            RegionCountry regionCountry = new RegionCountry()
            {
                Title = model.Title
            };
            var result = await regionServices.AddCountry(regionCountry);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RegionCountryUpdate model)
        {
            RegionCountry regionCountry = new RegionCountry()
            {
                Id = model.Id,
                Title = model.Title
            };
            var result = await regionServices.UpdateCountry(regionCountry);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RegionCountryDelete model)
        {
            var result = await regionServices.RemoveCountry(model.Id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
