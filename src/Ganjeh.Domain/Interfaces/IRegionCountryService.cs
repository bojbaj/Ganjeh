using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionCountryService
    {
        Task<TypedResult<ICollection<CountryDTO>>> GetAll();
        Task<TypedResult<CountryDTO>> Add(RegionCountry entity);
        Task<TypedResult<CountryDTO>> Update(RegionCountry entity);
        Task<TypedResult<bool>> Remove(Guid Id);
    }
}