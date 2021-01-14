using System.Threading.Tasks;
using Ganjeh.Api.Areas.Admin.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Models.Regions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class RegionCountriesController : AdminApiController
    {
        private readonly IRegionCountryService regionServices;
        private readonly ILogger<RegionCountriesController> _logger;

        public RegionCountriesController(IRegionCountryService regionServices, ILogger<RegionCountriesController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await regionServices.GetAll();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertRegionCountry model)
        {
            var result = await regionServices.Add(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateRegionCountry model)
        {          
            var result = await regionServices.Update(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRegionCountry model)
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
