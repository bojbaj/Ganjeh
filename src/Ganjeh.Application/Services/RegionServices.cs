using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Ganjeh.Domain.Models;

namespace Ganjeh.Application.Services
{
    public class RegionServices : IRegionServices
    {
        private readonly IRepository<RegionCountry> regionCountryRepo;
        public RegionServices(IRepository<RegionCountry> regionCountryRepo)
        {
            this.regionCountryRepo = regionCountryRepo;
        }

        public async Task<TypedResult<ICollection<RegionCountry>>> GetCountries()
        {
            try
            {
                ICollection<RegionCountry> result = await regionCountryRepo.GetAll();
                return new TypedResult<ICollection<RegionCountry>>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<RegionCountry>>(false, ex.Message, null);
            }
        }
        public async Task<TypedResult<RegionCountry>> AddCountry(RegionCountry regionCountry)
        {
            try
            {
                RegionCountry existsRecord = (await regionCountryRepo.GetList(1, 1, x => x.Title.Equals(regionCountry.Title))).FirstOrDefault();
                if (existsRecord != null)
                    throw new InvalidOperationException("This country name exists");
                RegionCountry result = await regionCountryRepo.Add(regionCountry);
                return new TypedResult<RegionCountry>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<RegionCountry>(false, ex.Message, null);
            }
        }
    }
}