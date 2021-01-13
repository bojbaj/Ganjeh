using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionCountryServices
    {
        Task<TypedResult<ICollection<CountryDTO>>> GetCountries();
        Task<TypedResult<CountryDTO>> AddCountry(RegionCountry regionCountry);
        Task<TypedResult<CountryDTO>> UpdateCountry(RegionCountry regionCountry);
        Task<TypedResult<bool>> RemoveCountry(Guid Id);
    }
}