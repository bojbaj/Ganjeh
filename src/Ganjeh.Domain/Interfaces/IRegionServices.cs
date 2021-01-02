using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionServices
    {
        Task<TypedResult<RegionCountry>> AddCountry(RegionCountry regionCountry);
        Task<TypedResult<ICollection<RegionCountry>>> GetCountries();
    }
}