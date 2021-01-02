using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Customer.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Customer.Controllers
{
    public class RegionCountryController : CustomerApiController
    {
        private readonly IRegionServices regionServices;
        private readonly ILogger<RegionCountryController> _logger;

        public RegionCountryController(IRegionServices regionServices, ILogger<RegionCountryController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<RegionCountry>> Get()
        {            
            return await regionServices.GetCountries();
        }
    }
}
