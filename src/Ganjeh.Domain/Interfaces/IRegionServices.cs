using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionServices
    {
        Task<TypedResult<ICollection<RegionCountry>>> GetCountries();
        Task<TypedResult<RegionCountry>> AddCountry(RegionCountry regionCountry);
        Task<TypedResult<RegionCountry>> UpdateCountry(RegionCountry regionCountry);
        Task<TypedResult<bool>> RemoveCountry(Guid Id);
    }
}