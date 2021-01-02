using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;

namespace Ganjeh.Application.Interfaces
{
    public interface IRegionServices
    {
        Task<ICollection<RegionCountry>> GetCountries();
    }
}