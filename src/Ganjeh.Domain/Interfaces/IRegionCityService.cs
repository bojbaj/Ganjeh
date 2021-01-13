using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionCityService
    {
        Task<TypedResult<ICollection<CityDTO>>> GetList(Guid StateId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<CityDTO>> Add(RegionCity entity);
        Task<TypedResult<CityDTO>> Update(RegionCity entity);
        Task<TypedResult<bool>> Remove(Guid Id);

    }
}