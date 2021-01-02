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

        Task<TypedResult<ICollection<RegionState>>> GetStates(Guid CountryId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<RegionState>> AddState(RegionState regionState);
        Task<TypedResult<RegionState>> UpdateState(RegionState regionState);
        Task<TypedResult<bool>> RemoveState(Guid Id);

        Task<TypedResult<ICollection<RegionCity>>> GetCities(Guid StateId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<RegionCity>> AddCity(RegionCity regionCity);
        Task<TypedResult<RegionCity>> UpdateCity(RegionCity regionCity);
        Task<TypedResult<bool>> RemoveCity(Guid Id);

    }
}