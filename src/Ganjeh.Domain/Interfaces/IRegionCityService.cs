using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;
using Ganjeh.Domain.Models.Regions;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionCityService
    {
        Task<TypedResult<ICollection<CityDTO>>> GetList(Guid StateId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<CityDTO>> Add(InsertRegionCity entity);
        Task<TypedResult<CityDTO>> Update(UpdateRegionCity entity);
        Task<TypedResult<bool>> Remove(Guid Id);

    }
}