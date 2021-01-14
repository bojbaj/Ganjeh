using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;
using Ganjeh.Domain.Models.Regions;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionCountryService
    {
        Task<TypedResult<ICollection<CountryDTO>>> GetAll();
        Task<TypedResult<CountryDTO>> Add(InsertRegionCountry entity);
        Task<TypedResult<CountryDTO>> Update(UpdateRegionCountry entity);
        Task<TypedResult<bool>> Remove(Guid Id);
    }
}