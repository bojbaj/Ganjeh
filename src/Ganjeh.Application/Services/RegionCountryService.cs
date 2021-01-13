using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Region;
using AutoMapper;
using Ganjeh.Application.i18n;

namespace Ganjeh.Application.Services
{
    public class RegionCountryService : IRegionCountryService
    {
        private readonly IRepository<RegionCountry> regionCountryRepo;
        private readonly IMapper _mapper;

        public RegionCountryService(IRepository<RegionCountry> regionCountryRepo, IMapper mapper)
        {
            this.regionCountryRepo = regionCountryRepo;
            _mapper = mapper;
        }

        public async Task<TypedResult<ICollection<CountryDTO>>> GetAll()
        {
            try
            {
                ICollection<RegionCountry> result = await regionCountryRepo.GetList();
                return new TypedResult<ICollection<CountryDTO>>(_mapper.Map<ICollection<CountryDTO>>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<CountryDTO>>(ex);
            }
        }
        public async Task<TypedResult<CountryDTO>> Add(RegionCountry regionCountry)
        {
            try
            {
                RegionCountry existsRecord = (await regionCountryRepo.GetList(condition: x => x.Title.Equals(regionCountry.Title))).FirstOrDefault();
                if (existsRecord != null)
                {
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_ALREADY_EXISTS);
                }
                RegionCountry result = await regionCountryRepo.Add(regionCountry);
                return new TypedResult<CountryDTO>(_mapper.Map<CountryDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<CountryDTO>(ex);
            }
        }
        public async Task<TypedResult<CountryDTO>> Update(RegionCountry regionCountry)
        {
            try
            {
                if (regionCountry.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException(ErrorMessages.ID_IS_REQUIRED);
                RegionCountry existsRecord = await regionCountryRepo.FindById(regionCountry.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);

                existsRecord.Title = regionCountry.Title;
                RegionCountry result = await regionCountryRepo.Update(existsRecord);
                return new TypedResult<CountryDTO>(_mapper.Map<CountryDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<CountryDTO>(ex);
            }
        }
        public async Task<TypedResult<Boolean>> Remove(Guid Id)
        {
            try
            {
                RegionCountry existsRecord = await regionCountryRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);
                Boolean result = await regionCountryRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(ex);
            }
        }
   }
}