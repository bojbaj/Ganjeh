using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionStateServices
    {
        Task<TypedResult<ICollection<StateDTO>>> GetStates(Guid CountryId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<StateDTO>> AddState(RegionState regionState);
        Task<TypedResult<StateDTO>> UpdateState(RegionState regionState);
        Task<TypedResult<bool>> RemoveState(Guid Id);
    }
}