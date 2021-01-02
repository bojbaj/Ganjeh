using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;

namespace Ganjeh.Domain.Interfaces
{
    public interface IRegionServices
    {
        Task<RegionCountry> AddCountry(RegionCountry regionCountry);
        Task<ICollection<RegionCountry>> GetCountries();
    }
}