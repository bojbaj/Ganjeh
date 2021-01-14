using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;
using Ganjeh.Domain.Models.Regions;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionStateService
    {
        Task<TypedResult<ICollection<StateDTO>>> GetList(Guid CountryId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<StateDTO>> Add(InsertRegionState entity);
        Task<TypedResult<StateDTO>> Update(UpdateRegionState entity);
        Task<TypedResult<bool>> Remove(Guid Id);
    }
}