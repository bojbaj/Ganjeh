using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ganjeh.Application.Services
{
    public class RegionServices : IRegionServices
    {
        private readonly IRepository<RegionCountry> regionCountryRepo;
        public RegionServices(IRepository<RegionCountry> regionCountryRepo)
        {
            this.regionCountryRepo = regionCountryRepo;
        }

        public async Task<ICollection<RegionCountry>> GetCountries()
        {
            return await regionCountryRepo.GetAll();
        }
        public async Task<RegionCountry> AddCountry(RegionCountry regionCountry)
        {
            return await regionCountryRepo.Add(regionCountry);
        }
    }
}