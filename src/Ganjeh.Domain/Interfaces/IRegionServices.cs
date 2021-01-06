using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionServices
    {
        Task<TypedResult<ICollection<CountryDTO>>> GetCountries();
        Task<TypedResult<CountryDTO>> AddCountry(RegionCountry regionCountry);
        Task<TypedResult<CountryDTO>> UpdateCountry(RegionCountry regionCountry);
        Task<TypedResult<bool>> RemoveCountry(Guid Id);

        Task<TypedResult<ICollection<StateDTO>>> GetStates(Guid CountryId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<StateDTO>> AddState(RegionState regionState);
        Task<TypedResult<StateDTO>> UpdateState(RegionState regionState);
        Task<TypedResult<bool>> RemoveState(Guid Id);

        Task<TypedResult<ICollection<CityDTO>>> GetCities(Guid StateId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<CityDTO>> AddCity(RegionCity regionCity);
        Task<TypedResult<CityDTO>> UpdateCity(RegionCity regionCity);
        Task<TypedResult<bool>> RemoveCity(Guid Id);

    }
}