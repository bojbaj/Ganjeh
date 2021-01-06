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
    public class RegionServices : IRegionServices
    {
        private readonly IRepository<RegionCountry> regionCountryRepo;
        private readonly IRepository<RegionState> regionStateRepo;
        private readonly IRepository<RegionCity> regionCityRepo;
        private readonly IMapper _mapper;

        public RegionServices(IRepository<RegionCountry> regionCountryRepo, IRepository<RegionState> regionStateRepo, IRepository<RegionCity> regionCityRepo, IMapper mapper)
        {
            this.regionCountryRepo = regionCountryRepo;
            this.regionStateRepo = regionStateRepo;
            this.regionCityRepo = regionCityRepo;
            _mapper = mapper;
        }

        public async Task<TypedResult<ICollection<CountryDTO>>> GetCountries()
        {
            try
            {
                ICollection<RegionCountry> result = await regionCountryRepo.GetList();
                return new TypedResult<ICollection<CountryDTO>>(_mapper.Map<ICollection<CountryDTO>>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<CountryDTO>>(false, ex.Message, null);
            }
        }
        public async Task<TypedResult<CountryDTO>> AddCountry(RegionCountry regionCountry)
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
                return new TypedResult<CountryDTO>(false, ex.Message, null);
            }
        }
        public async Task<TypedResult<CountryDTO>> UpdateCountry(RegionCountry regionCountry)
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
                return new TypedResult<CountryDTO>(false, ex.Message, null);
            }
        }
        public async Task<TypedResult<Boolean>> RemoveCountry(Guid Id)
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
                return new TypedResult<Boolean>(false, ex.Message, false);
            }
        }

        public async Task<TypedResult<ICollection<StateDTO>>> GetStates(Guid CountryId, int pageSize = 0, int pageNumber = 0)
        {
            try
            {
                ICollection<RegionState> result = await regionStateRepo
                    .GetList(condition: x => x.RegionCountryId.Equals(CountryId), pageSize: pageSize, pageNumber: pageNumber);
                return new TypedResult<ICollection<StateDTO>>(_mapper.Map<ICollection<StateDTO>>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<StateDTO>>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<StateDTO>> AddState(RegionState regionState)
        {
            try
            {
                ICollection<RegionState> existsRecords = await regionStateRepo
                    .GetList(condition: x => x.RegionCountryId == regionState.RegionCountryId && x.Title.Equals(regionState.Title));

                if (existsRecords.Any())
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_ALREADY_EXISTS);
                RegionState result = await regionStateRepo.Add(regionState);
                return new TypedResult<StateDTO>(_mapper.Map<StateDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<StateDTO>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<StateDTO>> UpdateState(RegionState regionState)
        {
            try
            {
                if (regionState.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException(ErrorMessages.ID_IS_REQUIRED);
                RegionState existsRecord = await regionStateRepo.FindById(regionState.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);

                existsRecord.RegionCountryId = regionState.RegionCountryId;
                existsRecord.Title = regionState.Title;
                RegionState result = await regionStateRepo.Update(existsRecord);
                return new TypedResult<StateDTO>(_mapper.Map<StateDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<StateDTO>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<bool>> RemoveState(Guid Id)
        {
            try
            {
                RegionState existsRecord = await regionStateRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);
                Boolean result = await regionStateRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(false, ex.Message, false);
            }
        }

        public async Task<TypedResult<ICollection<CityDTO>>> GetCities(Guid StateId, int pageSize = 0, int pageNumber = 0)
        {
            try
            {
                ICollection<RegionCity> result = await regionCityRepo
                    .GetList(condition: x => x.RegionStateId.Equals(StateId), pageSize: pageSize, pageNumber: pageNumber);
                return new TypedResult<ICollection<CityDTO>>(_mapper.Map<ICollection<CityDTO>>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<CityDTO>>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<CityDTO>> AddCity(RegionCity regionCity)
        {
            try
            {
                ICollection<RegionCity> existsRecords = await regionCityRepo
                    .GetList(condition: x => x.RegionStateId == regionCity.RegionStateId && x.Title.Equals(regionCity.Title));

                if (existsRecords.Any())
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_ALREADY_EXISTS);
                RegionCity result = await regionCityRepo.Add(regionCity);
                return new TypedResult<CityDTO>(_mapper.Map<CityDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<CityDTO>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<CityDTO>> UpdateCity(RegionCity regionCity)
        {
            try
            {
                if (regionCity.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException(ErrorMessages.ID_IS_REQUIRED);
                RegionCity existsRecord = await regionCityRepo.FindById(regionCity.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);

                existsRecord.RegionStateId = regionCity.RegionStateId;
                existsRecord.Title = regionCity.Title;
                RegionCity result = await regionCityRepo.Update(existsRecord);
                return new TypedResult<CityDTO>(_mapper.Map<CityDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<CityDTO>(false, ex.Message, null);
            }
        }

        public async Task<TypedResult<bool>> RemoveCity(Guid Id)
        {
            try
            {
                RegionCity existsRecord = await regionCityRepo.FindById(Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);
                Boolean result = await regionCityRepo.Delete(Id);
                return new TypedResult<Boolean>(result);
            }
            catch (Exception ex)
            {
                return new TypedResult<Boolean>(false, ex.Message, false);
            }
        }
    }
}