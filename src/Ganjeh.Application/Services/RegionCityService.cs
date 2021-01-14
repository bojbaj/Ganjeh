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
using Ganjeh.Domain.Models.Regions;

namespace Ganjeh.Application.Services
{
    public class RegionCityService : IRegionCityService
    {
        private readonly IRepository<RegionCity> regionCityRepo;
        private readonly IMapper _mapper;

        public RegionCityService(IRepository<RegionCity> regionCityRepo, IMapper mapper)
        {
            this.regionCityRepo = regionCityRepo;
            _mapper = mapper;
        }

        public async Task<TypedResult<ICollection<CityDTO>>> GetList(Guid StateId, int pageSize = 0, int pageNumber = 0)
        {
            try
            {
                ICollection<RegionCity> result = await regionCityRepo
                    .GetList(
                        condition: x => x.RegionStateId.Equals(StateId),
                        pageSize: pageSize,
                        pageNumber: pageNumber,
                        includes: $"{nameof(RegionState)},{nameof(RegionState)}.{nameof(RegionCountry)}");
                return new TypedResult<ICollection<CityDTO>>(_mapper.Map<ICollection<CityDTO>>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<ICollection<CityDTO>>(ex);
            }
        }

        public async Task<TypedResult<CityDTO>> Add(InsertRegionCity regionCity)
        {
            try
            {
                ICollection<RegionCity> existsRecords = await regionCityRepo
                    .GetList(condition: x => x.RegionStateId == regionCity.StateId && x.Title.Equals(regionCity.Title));

                if (existsRecords.Any())
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_ALREADY_EXISTS);
                
                RegionCity entity = _mapper.Map<RegionCity>(regionCity);
                RegionCity result = await regionCityRepo.Add(entity);
                return new TypedResult<CityDTO>(_mapper.Map<CityDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<CityDTO>(ex);
            }
        }

        public async Task<TypedResult<CityDTO>> Update(UpdateRegionCity regionCity)
        {
            try
            {
                if (regionCity.Id.Equals(Guid.Empty))
                    throw new InvalidOperationException(ErrorMessages.ID_IS_REQUIRED);
                RegionCity existsRecord = await regionCityRepo.FindById(regionCity.Id);
                if (existsRecord == null)
                    throw new InvalidOperationException(ErrorMessages.THIS_RECORD_DOES_NOT_EXISTS);

                existsRecord.RegionStateId = regionCity.StateId;
                existsRecord.Title = regionCity.Title;
                RegionCity result = await regionCityRepo.Update(existsRecord);
                return new TypedResult<CityDTO>(_mapper.Map<CityDTO>(result));
            }
            catch (Exception ex)
            {
                return new TypedResult<CityDTO>(ex);
            }
        }

        public async Task<TypedResult<bool>> Remove(Guid Id)
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
                return new TypedResult<Boolean>(ex);
            }
        }
    }
}