using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionCityServices
    {
        Task<TypedResult<ICollection<CityDTO>>> GetCities(Guid StateId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<CityDTO>> AddCity(RegionCity regionCity);
        Task<TypedResult<CityDTO>> UpdateCity(RegionCity regionCity);
        Task<TypedResult<bool>> RemoveCity(Guid Id);

    }
}