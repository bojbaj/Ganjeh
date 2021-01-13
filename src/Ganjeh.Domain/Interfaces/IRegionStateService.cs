using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionStateService
    {
        Task<TypedResult<ICollection<StateDTO>>> GetList(Guid CountryId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<StateDTO>> Add(RegionState entity);
        Task<TypedResult<StateDTO>> Update(RegionState entity);
        Task<TypedResult<bool>> Remove(Guid Id);
    }
}