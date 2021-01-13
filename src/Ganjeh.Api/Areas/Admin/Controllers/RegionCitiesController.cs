﻿using System;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Admin.Base;
using Ganjeh.Api.Areas.Admin.Models.Regions;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class RegionCitiesController : AdminApiController
    {
        private readonly IRegionCityServices regionServices;
        private readonly ILogger<RegionCitiesController> _logger;

        public RegionCitiesController(IRegionCityServices regionServices, ILogger<RegionCitiesController> logger)
        {
            this.regionServices = regionServices;
            _logger = logger;
        }

        [HttpGet("{stateId}")]
        public async Task<IActionResult> Get(Guid stateId)
        {
            var result = await regionServices.GetCities(stateId);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegionCityInsert model)
        {
            RegionCity regionCity = new RegionCity()
            {
                Title = model.Title,
                RegionStateId = model.StateId
            };
            var result = await regionServices.AddCity(regionCity);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RegionCityUpdate model)
        {
            RegionCity regionCity = new RegionCity()
            {
                Id = model.Id,
                Title = model.Title,
                RegionStateId = model.StateId
            };
            var result = await regionServices.UpdateCity(regionCity);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RegionCityDelete model)
        {
            var result = await regionServices.RemoveCity(model.Id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
